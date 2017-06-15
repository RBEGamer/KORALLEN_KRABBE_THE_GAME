using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follower : MonoBehaviour {


	public GameObject camera_object;
	public GameObject object_to_follow;
	public float smooth_follow_factor = 0.1f;
	public bool enable_follow = true;
	public bool enable_auto_lookat = true;

	public Vector3 offset_camera_object; //test





	void Awake(){
		if(this.tag == "MainCamera"){
			camera_object = this.gameObject;
		}
	}
	// Use this for initialization
	void Start () {
		//some checks optional
		if(camera_object == null){
			enable_follow = false;
			Debug.LogError("please insert the camera object");
			return;
		}
		//calcualte offset
		offset_camera_object = camera_object.transform.position - object_to_follow.transform.position;
	}

	// Update is called once per frame
	void Update () {
		//some checks
		if(camera_object == null || object_to_follow == null){return;}
		//simple lerp
		if(enable_follow){
			camera_object.transform.position = Vector3.Lerp(camera_object.transform.position, object_to_follow.transform.position + offset_camera_object, smooth_follow_factor);
		}
		//simple lookat optional
		if(enable_auto_lookat){
			camera_object.transform.LookAt(object_to_follow.transform.position);
		}
	}

	[ContextMenu("CENTER CAMERA TO OBJECT")]
	void center_camera_to_object(){
		offset_camera_object = new Vector3(object_to_follow.transform.position.x, object_to_follow.transform.position.y, offset_camera_object.z);
	}
}
