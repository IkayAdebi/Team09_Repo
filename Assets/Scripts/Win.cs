using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D collision)
	{
	//	if (collision.gameObject.tag == "Player") {
			SceneManager.LoadScene ("YouWin");
	//	}
	}


}
