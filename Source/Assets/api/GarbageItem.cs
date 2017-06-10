using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageItem : MonoBehaviour
{
    public float FallSpeed = 1;
    public Rigidbody OwnRigidBody;


    private void LateUpdate()
    {
        OwnRigidBody.AddForce(0, FallSpeed, 0, ForceMode.Acceleration);
    }
}
