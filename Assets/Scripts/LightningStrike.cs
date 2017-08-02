using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningStrike : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine("Fizzle");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Fizzle()
	{
		yield return new WaitForSeconds (0.1F);
		Destroy (gameObject);

	}
}
