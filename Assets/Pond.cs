using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pond : MonoBehaviour {
	public ParticleSystem rainy;
	public Sprite frozen;
	public Sprite thawed;
	public bool isFrozen;
	public GameObject player;
	private float prevSpeed = 0.22F;

	// Use this for initialization
	void Start () {

		player = GameObject.Find("Player 1");
		rainy.Stop ();
		isFrozen = false;
	}

	// Update is called once per frame
	void Update () {

	

		if (isFrozen == true) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = frozen;
		}
		else gameObject.GetComponent<SpriteRenderer> ().sprite = thawed;


	}

	IEnumerator Thaw() {
		yield return new WaitForSeconds(3);
		isFrozen = false;
		player.GetComponent<Player> ().moveSpeed = 0.22F;
		player.GetComponent<Player> ()._jumpStrength = 20;
		rainy.Play ();


	}

	void OnTriggerStay2D(Collider2D collision) {

		if (Input.GetKeyDown (KeyCode.P)) {
		//	prevSpeed = player.GetComponent<Player> ().moveSpeed;
			player.GetComponent<Player> ().moveSpeed = 0;
			player.GetComponent<Player> ()._jumpStrength = 0;
			rainy.Stop ();
			isFrozen = true;
			StartCoroutine ("Thaw");
		}

		/**else if (Input.GetKeyUp (KeyCode.P)) {
			isFrozen = false;
			player.GetComponent<Player> ().moveSpeed = 0.22F;
			player.GetComponent<Player> ()._jumpStrength = 20;
			rainy.Play ();
		} **/

		//if (collision.gameObject.name == "Player 1") {
		//if (isFrozen == false) {
		//	rainy.Play ();
		//}

	//	}
	}
		void OnTriggerExit2D(Collider2D collision) {

	/**	if (collision.gameObject.tag == "snow") {
			gameObject.GetComponent<SpriteRenderer> ().sprite = thawed;
		}

**/
		//if (collision.gameObject.name == "Player 1") {
			//	else 
		rainy.Stop ();

		//	}

	}
}
