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



			API.Current.Globals.coral_amount_max = 0;
			API.Current.Globals.coral_amount_death = 0;

			GameObject.Find("player").GetComponent<player_controller>().spawn();




			foreach (GameObject n in GameObject.FindGameObjectsWithTag("corals")) {
				n.GetComponent<coral_controller>().reset();
			}

			API.Current.Globals.game_state = Globals.GAME_STATES.GS_PLAYING;
		}




		if(API.Current.Globals.game_state == Globals.GAME_STATES.GS_PLAYING){
			if(API.Current.Globals.coral_amount_death >= API.Current.Globals.coral_amount_max){
				API.Current.Globals.game_state = Globals.GAME_STATES.GS_DIE;	
			}
		}





		if(API.Current.Globals.game_state == Globals.GAME_STATES.GS_DIE){

			API.Current.Globals.game_state = Globals.GAME_STATES.GS_MENU;

		}



	}
}
