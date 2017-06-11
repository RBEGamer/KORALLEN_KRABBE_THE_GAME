using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageItemCollider : MonoBehaviour
{
	void OnTriggerEnter(Collider _other){
		if(_other.gameObject.GetComponent<player_controller>() != null){
			_other.gameObject.GetComponent<player_controller>().start_schnipping_process(this.gameObject);
		}
	}

    public void remove_item()
    {
        Destroy(this.transform.parent.gameObject);
    }
}
