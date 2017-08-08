using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSmasher : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collision) {
		
		 if (collision.gameObject.name == "Rock") {
			GameObject rock = collision.gameObject;
			rock.GetComponent<rock> ().isFalling = true;
			GetComponent<AudioSource> ().Play ();

		}

}
}