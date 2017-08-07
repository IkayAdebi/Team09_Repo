using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningStrike : MonoBehaviour {

<<<<<<< HEAD
	// Use this for initialization
	void Start () {
//		StartCoroutine("Fizzle");
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (gameObject);
=======
    public GameObject wp;
    public WeatherPlayer wpScript;
    // Use this for initialization
    void Start () {
		StartCoroutine("Fizzle");
        wp = GameObject.Find("Player 2");
        wpScript = wp.GetComponent<WeatherPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!wpScript.inCheck)
        {
            gameObject.transform.position = new Vector3(-100, 100, 100);
            gameObject.SetActive(false);
        }
>>>>>>> 8548c9ead7acb528636a05b50e85b1297eea9c7b
	}

	/** IEnumerator Fizzle()
	{
	//	yield return new WaitForSeconds (0.01F);
		//Destroy (gameObject);

	//} **/
}
