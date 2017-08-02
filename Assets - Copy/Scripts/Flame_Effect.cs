using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame_Effect : MonoBehaviour {
    
    private bool isGrounded;
    public GameObject flame;

	// Use this for initialization
	void Start () {
        isGrounded = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (isGrounded)
        {
            Debug.Log("Woah... woah");
            Instantiate(flame, transform);
            gameObject.SetActive(false);
            transform.position = new Vector3(-100, -100, -100);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Collision Detection for Falling
        if (collision.gameObject.tag == "DeathBoundary")
        {
            gameObject.SetActive(false);
            transform.position = new Vector3(-100, -100, -100);
        }
        else
        {
            Debug.Log("Welp");
            isGrounded = true;
        }
    }

    // Checks if player has left the ground.
    void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}
