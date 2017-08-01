using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public string HORIZONTAL_AXIS = "Horizontal";
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, Input.GetAxis(HORIZONTAL_AXIS), 0));
	}
}
