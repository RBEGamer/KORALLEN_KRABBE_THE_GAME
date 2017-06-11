using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner_controller : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		this.name = "spawner_controller";	
	}
	
	// Update is called once per frame
	void Update () {



		if(API.Current.Globals.game_state == Globals.GAME_STATES.GS_SPAWN){

			GameObject.Find("player").GetComponent<player_controller>().spawn();

			API.Current.Globals.game_state = Globals.GAME_STATES.GS_PLAYING;
		}

	}
}
