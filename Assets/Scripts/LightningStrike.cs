using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningStrike : MonoBehaviour {
	public Sprite burntPlayer;
	// Use this for initialization
	void Start () {
				StartCoroutine("Fizzle");
	}

	// Update is called once per frame
	void Update () {
		//Destroy (gameObject);
	}
 IEnumerator Fizzle()
	{
		yield return new WaitForSeconds (0.3F);
		Destroy (gameObject);

	}


	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.name == "Player 1") {
			collision.gameObject.GetComponent<SpriteRenderer> ().sprite = burntPlayer;
		}
	}
}
