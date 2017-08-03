using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour {

    // Checks if player is on the ground.
    void OnTriggerEnter2D(Collider2D collision)
    {
        Player.isGrounded = true;
    }

    // Checks if player has left the ground.
    void OnTriggerExit2D(Collider2D collision)
    {
        Player.isGrounded = false;
    }
}
