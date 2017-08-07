using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
    public GameObject player;
    public GameObject wp;
    private Player script;
	// Use this for initialization
	void Start () {
        script = player.GetComponent<Player>();
        wp = GameObject.Find("Player 2");
    }
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            script.currentCheckpoint = gameObject;
        }
        wp.GetComponent<WeatherPlayer>().inCheck = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        wp.GetComponent<WeatherPlayer>().inCheck = false;
    }
}
