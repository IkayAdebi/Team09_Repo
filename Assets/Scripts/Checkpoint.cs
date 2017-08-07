using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
    public GameObject player;
<<<<<<< HEAD
=======
    public GameObject wp;
>>>>>>> 8548c9ead7acb528636a05b50e85b1297eea9c7b
    private Player script;
	// Use this for initialization
	void Start () {
        script = player.GetComponent<Player>();
<<<<<<< HEAD
	}
=======
        wp = GameObject.Find("Player 2");
    }
>>>>>>> 8548c9ead7acb528636a05b50e85b1297eea9c7b
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            script.currentCheckpoint = gameObject;
        }
<<<<<<< HEAD

=======
        wp.GetComponent<WeatherPlayer>().inCheck = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        wp.GetComponent<WeatherPlayer>().inCheck = false;
>>>>>>> 8548c9ead7acb528636a05b50e85b1297eea9c7b
    }
}
