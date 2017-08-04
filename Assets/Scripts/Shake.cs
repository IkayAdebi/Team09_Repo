using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    IEnumerator windShake()
    {
        yield return new WaitForSeconds(1);
    }

    IEnumerator snowShake()
    {
        yield return new WaitForSeconds(1);
    }

    IEnumerator lightningShake()
    {
        yield return new WaitForSeconds(1);
    }

    IEnumerator earthquakeShake()
    {
        yield return new WaitForSeconds(1);
    }

    IEnumerator fireShake()
    {
        yield return new WaitForSeconds(1);
    }

    public void beginWind()
    {
        StartCoroutine("windShake");
    }

    public void beginSnow()
    {
        StartCoroutine("snowShake");
    }

    public void beginLightning()
    {
        StartCoroutine("lightningShake");
    }

    public void beginEarthquake()
    {
        StartCoroutine("earthquakeShake");
    }

    public void beginFire()
    {
        StartCoroutine("fireShake");
    }

}
