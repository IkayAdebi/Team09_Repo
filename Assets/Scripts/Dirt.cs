using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt : MonoBehaviour {
	public Sprite seeded;
	public GameObject vine;
	private GameObject p1;
	private bool hasSeed;
	// Use this for initialization
	void Start () {

		p1 = GameObject.Find("Player 1");
		//Player PlayerScript = p1.GetComponent<Player>();
	}

	// Update is called once per frame
	void Update () {
	hasSeed = p1.GetComponent<Player>().hasSeed;
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player" && hasSeed == true )
		{
			Vector3 vinepos = transform.position - new Vector3(12, -4, 0);
			gameObject.GetComponent<SpriteRenderer> ().sprite = seeded;
			Instantiate (vine, vinepos, Quaternion.Euler(0,0,-13));
			p1.GetComponent<Player> ().hasSeed = false;
		}
	}




}
