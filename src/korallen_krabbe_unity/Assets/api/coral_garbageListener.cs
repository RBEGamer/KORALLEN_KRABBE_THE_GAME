using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class coral_garbageListener : MonoBehaviour
{
    public coral_controller Coral;
    public int GarbageCount = 0;

    void OnTriggerEnter(Collider _other)
    {
        GarbageCount++;
        Coral.HasGarbage = GarbageCount > 0;
    }

    void OnTriggerExit(Collider _other)
    {
        var tmp = GarbageCount - 1;
        if (tmp < 0)
            tmp = 0;
        GarbageCount = tmp;

        Coral.HasGarbage = GarbageCount > 0;
    }
}
