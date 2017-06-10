using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class coral_controller : MonoBehaviour {




	public float coral_health_percentage = 1.0f;


	public GameObject coral_food_particle_system;
	public GameObject coral_health_bar_empty_object;
	public GameObject coral_health_bar_full_object;


	public float food_avariable_timer_max = 5.0f;
	public float food_avariable_timer_curr = 5.0f;
	public bool food_update_enabled = true;
	// Use this for initialization
	void Start () {
		coral_food_particle_system.GetComponent<ParticleSystem>().Stop();
		coral_health_bar_empty_object.GetComponent<Image>().fillOrigin = 0;
		coral_health_bar_empty_object.GetComponent<Image>().fillOrigin = 1;

		food_avariable_timer_curr = food_avariable_timer_max;
	}


	
	// Update is called once per frame
	void Update () {
		if(food_update_enabled){
			food_avariable_timer_curr -= Time.deltaTime;
			if(food_avariable_timer_curr <= 0.0f){
				food_avariable_timer_curr = food_avariable_timer_max;
				set_food_avariable();
			}
		}
	}

	[ContextMenu("SET FOOD")]
	public void set_food_avariable(){
		coral_food_particle_system.GetComponent<ParticleSystem>().Play();
	}

	[ContextMenu("DELETE FOOD")]
	public void remove_food_avariable(){
		coral_food_particle_system.GetComponent<ParticleSystem>().Stop();
	}



	public void set_coral_health(float _val){
		if(_val > 1.0f){coral_health_percentage = 1.0f;}
		else if(_val < 0.0f){coral_health_percentage = 0.0f;}
		else{coral_health_percentage = _val;}

		//DIRTY
		coral_health_bar_empty_object.GetComponent<Image>().fillAmount = 1.0f-coral_health_percentage;
		coral_health_bar_full_object.GetComponent<Image>().fillAmount = coral_health_percentage;

	}




	void OnTriggerEnter(Collider _other){

		if(_other.name == API.Current.Globals.player_obj_name){
			remove_food_avariable();
		}
	}
}
