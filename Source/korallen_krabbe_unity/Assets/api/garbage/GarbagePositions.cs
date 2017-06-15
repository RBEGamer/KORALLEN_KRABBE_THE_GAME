using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GarbagePositions : MonoBehaviour
{
    public Transform SpawnPositions;

    public void IteratePosition(System.Action<Transform> onChild)
    {
        var childCount = SpawnPositions.childCount;
        for (int c = 0; c < childCount; c++)
        {
            var child = SpawnPositions.GetChild(c);
            onChild(child);
        }
    }
}
