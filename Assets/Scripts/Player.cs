using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    #region Variables

    #region Movement Info
    public const string HORIZONTAL_AXIS = "Horizontal";
    public const string VERTICAL_AXIS = "Vertical";

    private float _moveSpeed = .1f;
    private float _jumpStrength = 10f; // old value: 350
    private const float MAX_FALL_SPEED = -15;
    
    public static bool isGrounded;
    private bool isJumping;
    private bool isJumpCanceled;

    private Rigidbody2D _rb;

    Animator anim;
    #endregion

    #region Health Info
    public bool isAlive = true;
    #endregion

    #endregion

    // Use this for initialization
    void Start () {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        isGrounded = true;
        _rb.gravityScale *= 2;
        anim = GetComponent<Animator>();
	}

    void Update()
    {
        if (isAlive)
        {
            // Walking animation
            if (Input.GetAxis(HORIZONTAL_AXIS) != 0)
            {
                anim.SetBool("isWalking", true);
            } else
            {
                anim.SetBool("isWalking", false);
            }

            transform.position = new Vector3(transform.position.x + Input.GetAxis(HORIZONTAL_AXIS) * _moveSpeed, transform.position.y, 0);

            // Sets Jumping flags to true based off of player 1's input
            if (Input.GetButtonDown("Jump") && isGrounded) //&& !(Input.GetAxis(VERTICAL_AXIS) < 0))
            {
                isJumping = true;
            }
            if ((Input.GetButtonUp("Jump") || Input.GetAxis(VERTICAL_AXIS) < 0) && !isGrounded)
            {
                isJumpCanceled = true;
            }

            // Allows Player to go down faster
            if (Input.GetAxis(VERTICAL_AXIS) < 0 && !isGrounded)
            {
                _rb.AddForce(-Vector2.up * 60);
                isJumpCanceled = true;
            }

            // Sets a max speed for player's acceleration;
            if (_rb.velocity.y < MAX_FALL_SPEED)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, MAX_FALL_SPEED);
            }
        }
        print(_rb.velocity.y);
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
            if (_rb.velocity.y > _jumpStrength /2)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, _jumpStrength / 2);
            }
            isJumpCanceled = false;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Collision Detection for Falling
        if (collision.gameObject.tag == "DeathBoundary")
        {
            isAlive = false;
            StartCoroutine(OnDeath());        
        }
    }

    IEnumerator OnDeath()
    {
        // Death and Respawn Logic
        yield return new WaitForSeconds(.5f);
        transform.position = new Vector3(-8, 3, 0);
        isAlive = true;
        _rb.velocity = new Vector2(0, 0);
    }

}
