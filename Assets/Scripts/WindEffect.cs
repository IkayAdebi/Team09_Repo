﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindEffect : MonoBehaviour {

    public float windSpeed;
    public int lifetime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        StartCoroutine("timeTilDeath");
    }

    IEnumerator timeTilDeath()
    {
        for(int c = 0; c < lifetime + 1; c++)
        {
            if( c == lifetime)
            {
                gameObject.SetActive(false);
                transform.position = new Vector3 (-100, -100, -100);
            }
            yield return new WaitForSeconds(1);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("I need to blow my nose which could also be a wind pun hahaha");

        Vector2 windVector = new Vector2(-windSpeed, 0);
        if (other.gameObject.tag == "Player")
        {
            //other.gameObject.GetComponent<Rigidbody2D>().velocity = (-transform.right * windSpeed);
            other.gameObject.GetComponent<Rigidbody2D>().drag = 1f;
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(windVector);
        }

    }

    
}
