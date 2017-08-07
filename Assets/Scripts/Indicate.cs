using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicate : MonoBehaviour {
	private GameObject p2;
	public Sprite off;
	public Sprite on;
	public int index;

	private float Counter;
	private float Cooldown;

	// Use this for initialization
	void Start () {
		p2 = GameObject.Find("Player 2");
		//Cooldown = p2.GetComponent<WeatherPlayer> ().windCooldown;
	
		if (index == 0) {
			Cooldown = p2.GetComponent<WeatherPlayer> ().windCooldown;
		} 
		else if (index == 1) {
			Cooldown = p2.GetComponent<WeatherPlayer> ().snowCooldown;
		}
		else if (index == 2) {
			Cooldown = p2.GetComponent<WeatherPlayer> ().lightningCooldown;
		}
		else if (index == 3) {
			Cooldown = p2.GetComponent<WeatherPlayer> ().earthquakeCooldown;
		}
		else if (index == 4) {
			Cooldown = p2.GetComponent<WeatherPlayer> ().fireCooldown;
		}

	
	}
	
	// Update is called once per frame
	void Update () {

		Counter = p2.GetComponent<WeatherPlayer> ().windCounter;


		if (index == 0) {
			Counter = p2.GetComponent<WeatherPlayer> ().windCounter;
		} 
		else if (index == 1) {
			Counter = p2.GetComponent<WeatherPlayer> ().snowCounter;	
		}
		else if (index == 2) {
			Counter = p2.GetComponent<WeatherPlayer> ().lightningCounter;	
		}
		else if (index == 3) {
			Counter = p2.GetComponent<WeatherPlayer> ().earthquakeCounter;
		}
		else if (index == 4) {
			Counter = p2.GetComponent<WeatherPlayer> ().fireCounter;
		}




		if(Counter >= Cooldown) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = on;
		}
		else gameObject.GetComponent<SpriteRenderer> ().sprite = off;




	



	}
}
