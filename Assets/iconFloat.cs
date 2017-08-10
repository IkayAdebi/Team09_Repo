using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iconFloat : MonoBehaviour {
	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		StartCoroutine ("floating");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator floating () {
		while (true) {

			for (int i = 0; i < 7; i++) {
				transform.position += new Vector3 (0, 0.1f, 0);
				yield return new WaitForSeconds (0.1f);
			}
			for (int i = 0; i < 7; i++) {
				transform.position += new Vector3 (0, -0.1f, 0);
				yield return new WaitForSeconds (0.1f);
			}


		}
	}
}
