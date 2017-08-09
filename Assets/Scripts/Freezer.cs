using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freezer : MonoBehaviour {
	AudioSource freeze;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	//	Debug.Log ("hi");
	}



	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.name == "Pond") {
			GetComponent<AudioSource> ().Play ();
			GameObject pond = collision.gameObject;
			pond.GetComponent<Pond> ().isFrozen = true;
			//	Debug.Log ("hi");
		} 
	

}
}