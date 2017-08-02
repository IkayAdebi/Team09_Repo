using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowEffect : MonoBehaviour {

    public Player playerOne;
    private float initialState;

	// Use this for initialization
	void Start () {
        initialState = playerOne.moveSpeed;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("I need to blow my nose which could also be a wind pun hahaha");
        
        if (other.gameObject.tag == "Player")
        {
            playerOne.moveSpeed = initialState / 2;
        }

        Debug.Log(playerOne.moveSpeed);
    }

    void onTriggerExit2D(Collider2D other)
    {
        Debug.Log("Goodbye");
        if (other.gameObject.tag == "Player")
        {
            playerOne.moveSpeed = initialState;
        }
        Debug.Log(playerOne.moveSpeed);
    }
}
