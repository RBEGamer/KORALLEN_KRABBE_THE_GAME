using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class billboard_ui : MonoBehaviour {


	public GameObject object_to_lookup;
	public bool enable_lookat = true;
	public bool enable_aut_camera_find = true;
	// Use this for initialization
	void Start () {

		if(enable_aut_camera_find && object_to_lookup == null){
			search_for_main_cam();
		}

		if(object_to_lookup == null){
			Debug.LogError("please spcifiy a lookat object");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(!enable_lookat || object_to_lookup == null){
			enable_lookat = false;
			return;
		}
		object_to_lookup.transform.LookAt(object_to_lookup.transform.position);
	}


	[ContextMenu("FIND Main Camera")]
	public void search_for_main_cam(){
		object_to_lookup = GameObject.Find("Main Camera");

	}
}
