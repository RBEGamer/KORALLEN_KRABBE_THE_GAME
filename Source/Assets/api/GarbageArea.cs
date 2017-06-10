using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageArea : MonoBehaviour
{
    public BoxCollider OwnBoxCollider;
    public Transform OwnTransform;

    public List<Transform> Spawns;
    public bool IsAreaFullWithGarbage { get; set; }
    public bool HasTriggeredAreaFull = false;
    public int GarbageCount = 0;

    public void AddSpawnPosition(Transform child)
    {
        Spawns = Spawns ?? new List<Transform>();
        Spawns.Add(child);
    }

    public void OnGarbageLanded(GarbageItem item)
    {
        GarbageCount++;
        if(GarbageCount > API.Current.Globals.MaxGarbagePerArea && !HasTriggeredAreaFull)
        {
            HasTriggeredAreaFull = true;
            API.Current.GlobalEvents.TriggerGarbageAreaFull(this);
        }
    }

    public Vector3 GetRandowmSpawn()
    {
        var i = Random.Range(0, Spawns.Count);
        return Spawns[i].position;
    }

    public bool HasSpawns()
    {
        return Spawns != null && Spawns.Count != 0;
    }

    public bool HasItem(GarbageItem item)
    {
        return OwnBoxCollider.bounds.Contains(item.transform.position);
    }
}
