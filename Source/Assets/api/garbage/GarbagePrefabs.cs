using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbagePrefabs : MonoBehaviour
{
    public GameObject[] Objects;

    public GarbageItem CreateRandomGarbage()
    {
        var i = Random.Range(0, Objects.Length);
        return Instantiate(Objects[i]).GetComponent<GarbageItem>();
    }
}
