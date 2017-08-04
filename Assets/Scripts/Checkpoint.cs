using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
    public GameObject player;
    private Player script;
	// Use this for initialization
	void Start () {
        script = player.GetComponent<Player>();
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

    }
}
