using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningScript : MonoBehaviour {
	AudioSource lightning;
			public int lifetime;
	public GameObject bolt;
	public bool isReady = false;
		// Use this for initialization
		void Start () {
		
		lightning = gameObject.GetComponent<AudioSource> ();

		//StartCoroutine ("timeTilDeath");
		}

		// Update is called once per frame
		void Update () {
	//	if (Input.GetKeyUp (KeyCode.P)) { 
		if (isReady) {
			StartCoroutine ("timeTilDeath");
		}
		}	
	//}
		IEnumerator timeTilDeath()
		{
		yield return new WaitForSeconds(1);
	
		lightning.Play ();
		if (isReady == true) {
			Instantiate (bolt, transform.position - new Vector3(0, 12, 0), Quaternion.identity);
			isReady = false;	
		}
		yield return new WaitForSeconds(1);
	
		gameObject.SetActive(false);
		transform.position = new Vector3 (-100, -100, -100);
				
	} 
		
	/**IEnumerator timeTilDeath()
	{
		for(int c = 0; c < lifetime + 1; c++)
		{
			if(c == lifetime)
			{
				gameObject.SetActive(false);
				transform.position = new Vector3 (-100, -100, -100);
			}
			yield return new WaitForSeconds(1);
		Instantiate (bolt, transform.position, Quaternion.identity);
		}
	} **/


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


	

