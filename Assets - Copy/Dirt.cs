using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt : MonoBehaviour {
	public Sprite seeded;
	public GameObject vine;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			Vector3 vinepos = transform.position - new Vector3(12, -4, 0);
			gameObject.GetComponent<SpriteRenderer> ().sprite = seeded;
			Instantiate (vine, vinepos, Quaternion.Euler(0,0,-13));
		}
	}




}
