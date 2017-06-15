using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_manager : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		API.Current.Globals.game_state = Globals.GAME_STATES.GS_MENU;
	}
	
	// Update is called once per frame
	void Update () {
		
	}




	public void play_clicked(){
		API.Current.Globals.game_state = Globals.GAME_STATES.GS_SPAWN;
		this.gameObject.SetActive(false);

	}



	public void credits_clicked(){
		API.Current.Globals.game_state = Globals.GAME_STATES.GS_MENU;
		this.gameObject.SetActive(false);

	}
}
