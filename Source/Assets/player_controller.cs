using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour {



	public Vector3 should_have_position;
	public float movement_speed = 1.0f;
	// Use this for initialization
	void Start () {
		this.name = "player";
		should_have_position = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {



		this.transform.position = Vector3.Lerp(this.transform.position, should_have_position, movement_speed);
	}
		

}
