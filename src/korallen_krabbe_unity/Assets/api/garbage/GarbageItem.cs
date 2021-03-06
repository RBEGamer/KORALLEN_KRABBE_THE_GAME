﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageItem : MonoBehaviour
{
    public bool IsAlive = false;
    public bool HasLanded = false;
    public float FallSpeed = 1;
    public Rigidbody OwnRigidBody;
    public CapsuleCollider OwnCollider;
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

        if(OwnRigidBody.velocity.sqrMagnitude < 0.001f)
        {
            HasLanded = true;
            if (OnLanded != null)
                OnLanded(this);
        }
    }



	//void OnTriggerEnter(Collider _other){
	//	if(_other.gameObject.GetComponent<player_controller>() != null){
	//		_other.gameObject.GetComponent<player_controller>().start_schnipping_process(this.gameObject);
	//	}
	//}


	public void remove_item(){
		Destroy(this.gameObject);
	}
}
