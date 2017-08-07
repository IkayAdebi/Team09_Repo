using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iconFloat : MonoBehaviour {
	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine ("floating");
	}

	IEnumerator floating () {
		while (true) {
			rb.velocity = new Vector3 (0, 1, 0);
			yield return new WaitForSeconds (2);
			rb.velocity = new Vector3 (0, -1, 0);
			yield return new WaitForSeconds (2);
			rb.velocity = Vector3.zero;
		}
	}
}
