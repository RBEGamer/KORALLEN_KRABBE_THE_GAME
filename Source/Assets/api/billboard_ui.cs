using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class billboard_ui : MonoBehaviour {


	public GameObject object_to_lookup;
	public GameObject object_to_roate;
	public bool enable_lookat = true;
	public bool enable_aut_camera_find = true;
	public bool use_this_to_roate = true;
	// Use this for initialization
	void Start () {

		if(use_this_to_roate){
			object_to_roate = this.gameObject;
		}

		if(enable_aut_camera_find && object_to_lookup == null){
			search_for_main_cam();
		}

		if(object_to_lookup == null){
			Debug.LogError("please spcifiy a lookat object");
		}

		if(use_this_to_roate == null){
			Debug.LogError("please spcifiy a  object to rotate");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(!enable_lookat || object_to_lookup == null || use_this_to_roate == null){
			enable_lookat = false;
			return;
		}
		object_to_roate.transform.LookAt(object_to_lookup.transform.position);
	}


	[ContextMenu("FIND Main Camera")]
	public void search_for_main_cam(){
		object_to_lookup = GameObject.Find("Main Camera");

	}
}
