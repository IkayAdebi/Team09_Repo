using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatDeath : MonoBehaviour
{
    public int lifetime;

    IEnumerator deathCounter()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }

	// Use this for initialization
	void Start () {
        StartCoroutine("deathCounter");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
