using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement.isGrounded = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        PlayerMovement.isGrounded = false;

    }
}
