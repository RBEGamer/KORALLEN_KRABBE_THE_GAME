using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageGround : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //var rigidbody = collision.gameObject.GetComponent<Rigidbody>();
        //if (rigidbody == null) return;

        //var constraints = rigidbody.constraints;
        //constraints = RigidbodyConstraints.FreezeRotationX;
        ////rigidbody.constraints = constraints;
    }
}
