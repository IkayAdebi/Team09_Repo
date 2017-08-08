using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour {

    private FloorController jsC;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D collision)
    {
        /*  jsC.move(0, 0);
          jsC.move(1, 0);
          jsC.move(2, 0);
          jsC.move(3, 0);*/
        SceneManager.LoadScene ("YouWin");
	}


}
