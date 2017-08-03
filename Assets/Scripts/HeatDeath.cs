using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatDeath : MonoBehaviour
{
    public int lifetime;
    public bool doIDie;

    IEnumerator deathCounter()
    {
        yield return new WaitForSeconds(lifetime);
        gameObject.transform.position = new Vector3(-100, 100, 100);
        gameObject.SetActive(false);
    }

	// Use this for initialization
	void Start () {
        doIDie = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (doIDie)
        {
            doIDie = false;
            StartCoroutine("deathCounter");
        }
    }
}
