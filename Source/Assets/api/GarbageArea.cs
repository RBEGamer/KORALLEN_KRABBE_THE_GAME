using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageArea : MonoBehaviour
{
    public BoxCollider OwnBoxCollider;
    public Transform OwnTransform;

    public List<Transform> Spawns;
    public bool IsAreaFullWithGarbage { get; set; }

    public void AddSpawnPosition(Transform child)
    {
        Spawns = Spawns ?? new List<Transform>();
        Spawns.Add(child);
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
}
