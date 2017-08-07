using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    #region Variables

    #region Movement Info
    public const string HORIZONTAL_AXIS = "Horizontal";
    public const string VERTICAL_AXIS = "Vertical";

    // For Xbox controller
    public const string P1_HORIZONTAL_AXIS = "P1_Horizontal";
    public const string P1_VERTICAL_AXIS = "P1_Vertical";

    public float moveSpeed = .15f;
    public float _jumpStrength = 20f; // old value: 350
    private const float MAX_FALL_SPEED = -25f;
    
    public static bool isGrounded;
    public bool isJumping;
    private bool isJumpCanceled;
	    private Rigidbody2D _rb;

    Animator anim;
    #endregion

    #region Health Info
    public bool isAlive = true;
    #endregion

    #region Death Info
    public static int counter;
    public int lifetime;
    public Text counterText;
    #endregion

    #region earthquakeEffects
    public bool lowerSpeed = false;
    public bool increaseSpeed = false;
    public bool stopJump = false;
    public bool moveRestrict = false;
    public bool flip = false;
    #endregion

    #region Miscellaneous Info
    public bool hasSeed;
    public GameObject currentCheckpoint;
    #endregion

    #endregion

    // Use this for initialization
    void Start () {
        counter = lifetime;
        _rb = gameObject.GetComponent<Rigidbody2D>();
        isGrounded = true;
        _rb.gravityScale *= 3.5f;
        anim = GetComponent<Animator>();
        StartCoroutine("countToDeath");
        hasSeed = false;
	}

    IEnumerator countToDeath()
    {
        for(int c = 0; c < lifetime; c++)
        {
            counter--;
            counterText.text = "Seconds left: " + (counter + 1);
            yield return new WaitForSeconds(1);
        }
        SceneManager.LoadScene("GameOver");
    }

    void Update()
    {
        if (isAlive)
        {
            // Walking animation
            if ((Input.GetAxis(HORIZONTAL_AXIS) != 0 || Input.GetAxis(P1_HORIZONTAL_AXIS) != 0) && !moveRestrict)
            {
                anim.SetBool("isWalking", true);

                // Flip Character based off of movement
                if (Input.GetAxis(HORIZONTAL_AXIS) > 0 || Input.GetAxis(P1_HORIZONTAL_AXIS) > 0.2f)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                else if (Input.GetAxis(HORIZONTAL_AXIS) < 0 || Input.GetAxis(P1_HORIZONTAL_AXIS) < -0.2f)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
            }
            else
            {
                anim.SetBool("isWalking", false);
            }

            // Move character left and right
            if (!moveRestrict)
            {
                if (Input.GetAxis(P1_HORIZONTAL_AXIS) == 0)
                    if (!flip)
                        transform.position = new Vector3(transform.position.x + Input.GetAxis(HORIZONTAL_AXIS) * moveSpeed, transform.position.y, 0);
                    else
                        transform.position = new Vector3(transform.position.x - Input.GetAxis(HORIZONTAL_AXIS) * moveSpeed, transform.position.y, 0);
                else
                {
                    if (!flip)
                        transform.position = new Vector3(transform.position.x + Input.GetAxis(P1_HORIZONTAL_AXIS) * moveSpeed, transform.position.y, 0);
                    else
                        transform.position = new Vector3(transform.position.x - Input.GetAxis(P1_HORIZONTAL_AXIS) * moveSpeed, transform.position.y, 0);

                }
            }

            // Sets Jumping flags to true based off of player 1's input
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                if (!stopJump && !moveRestrict)
                {
                    isJumping = true;
                }
            }
            if ((Input.GetButtonUp("Jump") || Input.GetAxis(VERTICAL_AXIS) < -0.5f || Input.GetAxis(P1_VERTICAL_AXIS) < -0.6f) && !isGrounded)
            {
                isJumpCanceled = true;
            }

            // Allows Player to go down faster
            if (Input.GetAxis(VERTICAL_AXIS) < -0.5f && !isGrounded)
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
		if (collision.gameObject.tag == "Win")
		{
			Debug.Log ("Hello");
			SceneManager.LoadScene ("YouWin");
		
		}
		else if (collision.gameObject.tag == "DeathBoundary")
        {
            isAlive = false;
            StartCoroutine(OnDeath());        
        }

		else if (collision.gameObject.tag == "Collectible")
		{
			hasSeed = true;
		}
        

    }

   /** private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Collectible")
        {
            hasSeed = true;
        }
    } **/

    IEnumerator OnDeath()
    {
        // Death and Respawn Logic
        yield return new WaitForSeconds(.5f);
        if (currentCheckpoint == null)
        {
            transform.position = new Vector3(-10, 1, 0);
        }
        else
        {
            transform.position = currentCheckpoint.transform.position;
        }
        isAlive = true;
        _rb.velocity = new Vector2(0, 0);
    }

}
