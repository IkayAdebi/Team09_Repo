using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningScript : MonoBehaviour {

			public int lifetime;
	public GameObject bolt;

		// Use this for initialization
		void Start () {
		
		}

		// Update is called once per frame
		void Update () {
		//if (Input.GetKeyUp (KeyCode.P)) { 
			StartCoroutine ("timeTilDeath");
		//}
		}

		IEnumerator timeTilDeath()
		{
		yield return new WaitForSeconds(1);
	
	
		Instantiate (bolt, transform.position, Quaternion.identity);

		yield return new WaitForSeconds(1);
	
		gameObject.SetActive(false);
		transform.position = new Vector3 (-100, -100, -100);
				}

		
	//saved
			
	//void OnTriggerStay2D(Collider2D other)
	//	{
			//Debug.Log("Testing");

			//Vector2 windVector = new Vector2(-windSpeed, 0);
			//if (other.gameObject.tag == "Player")
			//{
				//other.gameObject.GetComponent<Rigidbody2D>().velocity = (-transform.right * windSpeed);
			//	other.gameObject.GetComponent<Rigidbody2D>().drag = 1f;
			//	other.gameObject.GetComponent<Rigidbody2D>().AddForce(windVector);

	//	}

		}


	

