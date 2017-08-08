using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {
	public Sprite impale;
	public GameObject corpse;
	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.name == "Player 1") {
			collision.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			GameObject p1 = collision.gameObject;
			Instantiate (corpse, p1.transform.position, Quaternion.identity);
			collision.gameObject.GetComponent<Player> ().isAlive = false;
		}

	}

	// Update is called once per frame
	void Update () {
		
	}
}
