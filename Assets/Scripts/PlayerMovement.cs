using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    #region Variables
    private string HORIZONTAL_AXIS = "Horizontal";
    private string VERTICAL_AXIS = "Vertical";

    private float _moveSpeed = .1f;
    private float _jumpStrength = 350f;
    
    public static bool isGrounded;

    private Rigidbody2D _rb;
    #endregion

    // Use this for initialization
    void Start () {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        isGrounded = true;
	}

    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            _rb.AddForce(Vector2.up * _jumpStrength);
        }
         if (Input.GetButtonUp("Jump") && !isGrounded)
        {
            _rb.AddForce(-Vector2.up * _jumpStrength/2);
        }

    }

    void FixedUpdate () {
        transform.position = new Vector3(transform.position.x + Input.GetAxis(HORIZONTAL_AXIS) * _moveSpeed, transform.position.y, 0);
    }
}
