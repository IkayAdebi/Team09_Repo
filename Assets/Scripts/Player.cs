using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    #region Variables

    #region Movement Info
    public string HORIZONTAL_AXIS = "Horizontal";
    public string VERTICAL_AXIS = "Vertical";

    private float _moveSpeed = .1f;
    private float _jumpStrength = 7f; // old value: 350
    
    public static bool isGrounded;
    private bool isJumping;
    private bool isJumpCanceled;

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

        // Sets Jumping flags to true based off of player 1's input
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }
        if ((Input.GetButtonUp("Jump") || Input.GetAxis(VERTICAL_AXIS) < 0) && !isGrounded)
        {
            isJumpCanceled = true;
        }

        ////Old Jumping Logic
        //if (Input.GetButtonDown("Jump") && isGrounded)
        //{
        //    _rb.AddForce(Vector2.up * _jumpStrength);
        //}
        //if (Input.GetButtonUp("Jump") && !isGrounded)
        //{
        //    _rb.AddForce(-Vector2.up * _jumpStrength / 1.5f);
        //}

        // Allows Player to go down faster
        if (Input.GetAxis(VERTICAL_AXIS) < 0 && !isGrounded)
        {
            _rb.AddForce(-Vector2.up * _jumpStrength / 2);
        }

    }

    private void FixedUpdate()
    {
        // Default jump
        if (isJumping)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpStrength);
            isJumping = false;
        }

        // If jump button is held for shorter time, player jumps at a shorter height
        if (isJumpCanceled)
        {
            if (_rb.velocity.y > _jumpStrength / 2)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, _jumpStrength / 2);
            }
            isJumpCanceled = false;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DeathBoundary")
        {
            StartCoroutine(OnDeath());
        }
    }


    IEnumerator OnDeath()
    {
        yield return new WaitForSeconds(.5f);
        transform.position = new Vector3(-6, 0, 0);
    }

}
