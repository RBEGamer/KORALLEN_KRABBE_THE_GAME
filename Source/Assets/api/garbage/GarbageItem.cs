using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageItem : MonoBehaviour
{
    public bool IsAlive = false;
    public bool HasLanded = false;
    public float FallSpeed = 1;
    public Rigidbody OwnRigidBody;
    public System.Action<GarbageItem> OnLanded;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1.0f);
        IsAlive = true;
    }

    private void LateUpdate()
    {
        OwnRigidBody.AddForce(0, FallSpeed, 0, ForceMode.Acceleration);
    }


    private void FixedUpdate()
    {
        if (!IsAlive) return;
        if (HasLanded) return;

        if(OwnRigidBody.velocity.sqrMagnitude < 0.1f)
        {
            HasLanded = true;
            if (OnLanded != null)
                OnLanded(this);
        }
    }
}
