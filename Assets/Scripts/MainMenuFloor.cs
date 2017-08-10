using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuFloor : MonoBehaviour {

  //  private FloorController jsC;
    public static bool dontpush;

	// Use this for initialization
	void Start () {
        dontpush = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!dontpush)
        {
            dontpush = true;
         //   jsC.move(0, 0);
         //   jsC.move(1, 0);
        //    jsC.move(2, 0);
         //   jsC.move(3, 0);
        }

	}
}
