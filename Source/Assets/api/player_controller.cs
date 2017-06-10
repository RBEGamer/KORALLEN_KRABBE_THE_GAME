using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour {


	private Animator anim;
	public Vector3 should_have_position;
	public float movement_speed = 1.0f;
	public bool enable_movement = true;
	public float schnipping_timer_max = 1.0f;
	private float schnipping_timer_curr = 0.5f;



	public float player_hungry = 100;
	public float player_hungry_dec_amount = 1;
	public float dec_hung_timer_max = 0.5f;
	private float dev_hung_timer_curr = 0.5f;


	private GameObject garbage_to_del = null;
	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator>();
		enable_movement = true;
		anim.SetBool("is_idle", true);
		anim.SetBool("is_eating", false);
		anim.SetBool("is_schnipping", false);
		anim.SetBool("is_moving", false);
		this.name = "player";
		should_have_position = this.transform.position;
	}


	// Update is called once per frame
	void Update () {



		if(dev_hung_timer_curr >= 0.0f){
			dev_hung_timer_curr = dec_hung_timer_max;
			player_hungry -= player_hungry_dec_amount;
			if(player_hungry < 0){
				//TODO LOOSE
			}
		}



		if((should_have_position - this.gameObject.transform.position).magnitude > 0.0f){
			anim.SetBool("is_idle", false);
			anim.SetBool("is_moving", true);
		}else{
			anim.SetBool("is_idle", true);
			anim.SetBool("is_moving", false);
		}


		if(enable_movement){
		this.transform.position = Vector3.Lerp(this.transform.position, should_have_position, movement_speed);
			if((should_have_position - this.gameObject.transform.position).magnitude > 0.0f){
				anim.SetBool("is_idle", false);
				anim.SetBool("is_moving", true);
			}else{
				anim.SetBool("is_idle", true);
				anim.SetBool("is_moving", false);
			}

		}



		if(!enable_movement &&  schnipping_timer_curr >= 0.0f){
			schnipping_timer_curr -= Time.deltaTime;

			if(schnipping_timer_curr < 0.0f){
				enable_movement = true;
				anim.SetBool("is_schnipping", false);
				if(garbage_to_del != null){
				garbage_to_del.GetComponent<GarbageItem>().remove_item();
					garbage_to_del = null;
				}
			}
		}
	}
		


	public void stock_hungry(int _val){
		player_hungry += _val;
	}
	public void start_schnipping_process(GameObject _other){
		Debug.Log("bla");
		schnipping_timer_curr=schnipping_timer_max;
		enable_movement = false;
		garbage_to_del = _other;
		anim.SetBool("is_idle", false);
		anim.SetBool("is_eating", false);
		anim.SetBool("is_schnipping", true);
		anim.SetBool("is_moving", false);

	}

}
