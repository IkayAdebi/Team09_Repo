using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseOverlay : MonoBehaviour {

    public GameObject canvas;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Player.pause)
        {
            canvas.SetActive(true); ;
        }
        else
        {
            canvas.SetActive(false);
        }
	}
}
