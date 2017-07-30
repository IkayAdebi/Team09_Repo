using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    #region Variables

    #region Movement Info
    public string HORIZONTAL_AXIS = "Horizontal";
    public string VERTICAL_AXIS = "Vertical";

    private float _moveSpeed = .1f;
    private float _jumpStrength = 350f;
    
    public static bool isGrounded;

    private Rigidbody2D _rb;
    #endregion

    #region Health Info
    public bool isAlive = true;
    #endregion

    #endregion

    // Use this for initialization
    void Start () {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        isGrounded = true;
	}

    void Update()
    {
        transform.position = new Vector3(transform.position.x + Input.GetAxis(HORIZONTAL_AXIS) * _moveSpeed, transform.position.y, 0);

        //Jumping Logic
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            _rb.AddForce(Vector2.up * _jumpStrength);
        }
        if (Input.GetButtonUp("Jump") && !isGrounded)
        {
            _rb.AddForce(-Vector2.up * _jumpStrength / 2);
        }

        // Allows Player to go down faster
        if (Input.GetAxis(VERTICAL_AXIS) < 0 && !isGrounded)
        {
            _rb.AddForce(-Vector2.up * _jumpStrength / 2);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DeathBoundary")
        {
            transform.position = new Vector3(-6, 0, 0);
        }
    }


    private void OnDeath()
    {
        
    }

}
