using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pond : MonoBehaviour {
	//public ParticleSystem rainy;
	public Sprite frozen;
	public Sprite thawed;
	public Sprite playernorm;
	public Sprite playerfroze;
	public bool isFrozen;
	public GameObject player;
	public GameObject freezee;
	public bool playerFrozen;
	public int freezeTime;

	// Use this for initialization
	void Start () {

		player = GameObject.Find("Player 1");
		//rainy.Stop ();
		isFrozen = false;
	}

	// Update is called once per frame
	void Update () {


		if (isFrozen == true) {
			StartCoroutine ("tempFreeze");
		}
	


	}


	IEnumerator tempFreeze() {
		playerFrozen = true;
		yield return new WaitForSeconds(1);
		playerFrozen = false;
		isFrozen = false;

	}

	IEnumerator Thaw() {
		//isFrozen = true;
		gameObject.GetComponent<SpriteRenderer> ().sprite = frozen;
		player.GetComponent<Player> ().moveRestrict = true;

	//	rainy.Stop ();
		player.GetComponent<SpriteRenderer> ().sprite = playerfroze;
		yield return new WaitForSeconds(freezeTime);
	
		player.GetComponent<SpriteRenderer> ().sprite = playernorm;
		gameObject.GetComponent<SpriteRenderer> ().sprite = thawed;
		player.GetComponent<Player> ().moveRestrict = false;

//		rainy.Play ();


	}

	IEnumerator FakeThaw() {
		gameObject.GetComponent<SpriteRenderer> ().sprite = frozen;
		yield return new WaitForSeconds(freezeTime);
		gameObject.GetComponent<SpriteRenderer> ().sprite = thawed;
	}

	void OnTriggerStay2D(Collider2D collision) {
		//rainy.Play ();
		if (playerFrozen && collision.gameObject.name == "Player 1") {
			//	prevSpeed = player.GetComponent<Player> ().moveSpeed;
		

			StartCoroutine ("Thaw");
			//freezeTime = false;
		}
		//else if (isFrozen) {

			//StartCoroutine ("FakeThaw");
		//}


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
//		rainy.Stop ();

		//	}

	}
}
