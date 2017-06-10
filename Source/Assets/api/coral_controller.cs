using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class coral_controller : MonoBehaviour {




	private float coral_health_percentage = 1.0f;

	private Animator anim = null;
	public GameObject coral_food_particle_system;
	public GameObject coral_health_bar_object;

	public GameObject coral_model_holder;
	public float food_avariable_timer_max = 5.0f;
	public float food_avariable_timer_curr = 5.0f;
	public bool food_update_enabled = true;

	public int inc_player_hung  = 5;
	// Use this for initialization
	void Start () {



		if(coral_model_holder == null){
			Debug.LogError("please spcify a model for the corals");
		}

		anim = coral_model_holder.GetComponent<Animator>();
		if(anim == null){
			Debug.LogError("the model must have a animator");
		}

		anim.SetBool("is_wedel", true);
		anim.speed = 1.0f;
		coral_food_particle_system.GetComponent<ParticleSystem>().Stop();
		coral_health_bar_object.GetComponent<Slider>().value = 1.0f -coral_health_percentage;

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



		if(coral_health_percentage <= 0.0f){
			//TODO DIE
			anim.SetBool("is_wedel", false);
			food_update_enabled = false;
		}
	}

	[ContextMenu("SET FOOD")]
	public void set_food_avariable(){
		if(!food_update_enabled){return;}
		coral_food_particle_system.GetComponent<ParticleSystem>().Play();
		anim.SetBool("is_wedel", false);
	}

	[ContextMenu("DELETE FOOD")]
	public void remove_food_avariable(){
		coral_food_particle_system.GetComponent<ParticleSystem>().Stop();
		anim.SetBool("is_wedel", true);
	}



	public void set_coral_health(float _val){
		if(_val > 1.0f){coral_health_percentage = 1.0f;}
		else if(_val < 0.0f){coral_health_percentage = 0.0f;}
		else{coral_health_percentage = _val;}
		anim.speed = coral_health_percentage;
		//DIRTY
		coral_health_bar_object.GetComponent<Slider>().value = 1.0f -coral_health_percentage;

	}




	void OnTriggerEnter(Collider _other){

		if(_other.name == API.Current.Globals.player_obj_name){
			remove_food_avariable();
			_other.GetComponent<player_controller>().stock_hungry(inc_player_hung);
		}
	}
}
