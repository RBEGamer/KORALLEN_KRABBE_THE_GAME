using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class coral_controller : MonoBehaviour {




	public float coral_health_percentage = 1.0f;



	public GameObject coral_health_bar_empty_object;
	public GameObject coral_health_bar_full_object;
	// Use this for initialization
	void Start () {
		coral_health_bar_empty_object.GetComponent<Image>().fillOrigin = 0;
		coral_health_bar_empty_object.GetComponent<Image>().fillOrigin = 1;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		set_coral_health(coral_health_percentage);
	}



	public void set_coral_health(float _val){
		if(_val > 1.0f){coral_health_percentage = 1.0f;}
		else if(_val < 0.0f){coral_health_percentage = 0.0f;}
		else{coral_health_percentage = _val;}

		//DIRTY
		coral_health_bar_empty_object.GetComponent<Image>().fillAmount = 1.0f-coral_health_percentage;
		coral_health_bar_full_object.GetComponent<Image>().fillAmount = coral_health_percentage;

	}
}
