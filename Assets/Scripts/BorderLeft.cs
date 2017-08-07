using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderLeft : MonoBehaviour {
	public GameObject p2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject == p2) {

			p2.transform.position = new Vector3(transform.position.x + 10, transform.position.y, 0);

		}
	}

}
