using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {
	public Sprite impale;
	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.name == "Player 1") {
			collision.gameObject.GetComponent<SpriteRenderer> ().sprite = impale;
		}

	}

	// Update is called once per frame
	void Update () {
		
	}
}
