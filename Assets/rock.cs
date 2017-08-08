using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock : MonoBehaviour {
	public bool isFalling = false;
	public ParticleSystem rockPiece;
	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		//gameObject.GetComponent<ParticleSystem> ().Stop ();
		rb = gameObject.GetComponent<Rigidbody2D> ();
		rockPiece = gameObject.GetComponent<ParticleSystem> ();
		rockPiece.Stop ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isFalling == true) {
			rb.constraints = RigidbodyConstraints2D.None;
		}
			

	}
	IEnumerator cracking () {
		//Instantiate (rockPiece, transform.position, Quaternion.identity);
		rockPiece.Play ();
		yield return new WaitForSeconds (0.5f);
		gameObject.SetActive (false);
	} 

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "DeathBoundary" || collision.gameObject.tag == "Platform" ||  collision.gameObject.tag == "Player") {
			

			gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			StartCoroutine ("cracking");
		} 
}
}