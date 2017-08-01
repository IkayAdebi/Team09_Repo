using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {

    [SerializeField]
    private bool isMouseDown = false;

    // On mouse down
    private void OnMouseDown()
    {
        print("Mouse Down");
        isMouseDown = true;
    }

    private void OnMouseUp()
    {
        print("Mouse Up");
        isMouseDown = false;
    }
}
