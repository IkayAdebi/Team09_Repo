using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame_Effect : MonoBehaviour {
    
    private bool isGrounded;
    public GameObject flame;

    // Use this for initialization
    void Start() {
        isGrounded = false;
    }
	
	// Update is called once per frame
	void Update ()
    {

    //    gameObject.GetComponent<Rigidbody2D>().AddForce(-transform.up * 20);

        gameObject.transform.rotation.z.Equals(0);
        gameObject.GetComponent<Rigidbody2D>().AddForce(-transform.up * 20);

        if (isGrounded)
        {
           
            flame.SetActive(true);
            flame.GetComponent<HeatDeath>().doIDie = true;
            flame.transform.position = gameObject.transform.position;
            isGrounded = false;
            gameObject.GetComponent<Rigidbody2D>().IsAwake();
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
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Player")
        {
            isGrounded = true;
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
            gameObject.GetComponent<Rigidbody2D>().Sleep();
        }
    }
}
