using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowEffect : MonoBehaviour {

    public Player playerOne;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("I need to blow my nose which could also be a wind pun hahaha");
        
        if (other.gameObject.tag == "Player")
        {
            playerOne.
        }

    }
}
