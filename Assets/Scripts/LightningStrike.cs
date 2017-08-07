using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningStrike : MonoBehaviour {

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
	}

	IEnumerator Fizzle()
	{
		yield return new WaitForSeconds (0.1F);
		Destroy (gameObject);

	}
}
