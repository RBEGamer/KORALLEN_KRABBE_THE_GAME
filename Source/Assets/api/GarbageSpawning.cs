using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GarbageSpawning : MonoBehaviour
{
    public int AreaCount = 4;
    public float SpawnInterval = 2;
    public GarbageArea AreaPrefab;
    public GarbagePrefabs GarbagePrefabs;

    public List<GarbageArea> AllAreas;

    public GarbagePositions SpawnPositions;

    [ContextMenu("Spawn Areas")]
    void _SpawnArea()
    {
        AllAreas = AllAreas ?? new List<GarbageArea>();
        AllAreas.Clear();

        for (int c = 0; c < AreaCount; c++)
        {
            var area = Instantiate(AreaPrefab.gameObject).GetComponent<GarbageArea>();
            var size = area.OwnBoxCollider.bounds;

            var pos = new Vector3(0, 0, 0);
            pos.y = c * size.size.y;

            area.OwnTransform.position = pos;
            AllAreas.Add(area);
        }

        AssignPositionToArea();
    }

    void AssignPositionToArea()
    {
        SpawnPositions.IteratePosition((child) =>
        {
            for (int c = 0; c < AllAreas.Count; c++)
            {
                var area = AllAreas[c];
                if (area.OwnBoxCollider.bounds.Contains(child.transform.position))
                {
                    area.AddSpawnPosition(child);
                    break;
                }
            }
        });
    }

    [ContextMenu("Spawn")]
    void _Spawn()
    {
        API.Current.GlobalEvents.TriggerNewSpawn();

        var obj = GarbagePrefabs.CreateRandomGarbage();
        var pos = GetSpawnPosition();
        obj.OnLanded = OnItemLanded;

        obj.transform.position = pos + new Vector3(0, 10, 0);
    }

    void OnItemLanded(GarbageItem item)
    {
        var area = _GetAreaOfItem(item);
        if(area == null)
        {
            Destroy(item.gameObject);
        }

        area.OnGarbageLanded(item);
    }

    GarbageArea _GetAreaOfItem(GarbageItem item)
    {
        for (int c = 0; c < AllAreas.Count; c++)
        {
            var area = AllAreas[c];
            if(area.HasItem(item))
            {
                return area;
            }
        }

        return null;
    }

    public Vector3 GetSpawnPosition()
    {
        var area = GetRandomFreeArea();
        if (area != null)
        {
            return area.GetRandowmSpawn();
        }
        else
        {
            API.Current.GlobalEvents.TriggerGameOver();
            //Game Over
        }
        return Vector3.zero;
    }

    public GarbageArea GetRandomFreeArea()
    {
        for (int c = 0; c < AllAreas.Count; c++)
        {
            var i = Random.Range(0, AllAreas.Count);
            var area = AllAreas[i];
            if (area.IsAreaFullWithGarbage || !area.HasSpawns()) continue;

            return area;
        }

        return null;
    }

    public bool IsAnyAreaFree()
    {
        for (int c = 0; c < AllAreas.Count; c++)
        {
            var area = AllAreas[c];
            if (!area.IsAreaFullWithGarbage)
                return true;
        }
        return false;
    }


    private float _t = 0;
    private void LateUpdate()
    {
        if(_t > SpawnInterval)
        {
            _Spawn();
            _t = 0;
            return;
        }

        _t += Time.deltaTime;
    }
}
