using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatDeath : MonoBehaviour
{
    public int lifetime;
    public bool doIDie;
    public GameObject wp;
    public WeatherPlayer wpScript;

    IEnumerator deathCounter()
    {
        yield return new WaitForSeconds(lifetime);
        gameObject.transform.position = new Vector3(-100, 100, 100);
        gameObject.SetActive(false);
    }

	// Use this for initialization
	void Start () {
        doIDie = true;
        wp = GameObject.Find("Player 2");
        wpScript = wp.GetComponent<WeatherPlayer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!wpScript.inCheck)
        {
            gameObject.transform.position = new Vector3(-100, 100, 100);
            gameObject.SetActive(false);
        }
        if (doIDie)
        {
            doIDie = false;
            StartCoroutine("deathCounter");
        }
    }
}
