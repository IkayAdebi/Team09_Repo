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
	private Rigidbody2D _rb;
	public ParticleSystem drop;
	public Sprite normalPlayer;
	public GameObject corpse;
    Animator anim;
	public AudioClip jump;
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
    public int hasSeed;
    public GameObject currentCheckpoint;
    private FloorController jsC;
	private AudioSource playeraudio;
	public AudioClip winsound;
	public AudioClip dyingsfx;
	public AudioClip obtainseed;
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

        hasSeed = 0;

      

	}
	void Awake () {
		playeraudio = GetComponent<AudioSource> ();

	}

    IEnumerator countToDeath()
    {
        for(int c = 0; c < lifetime; c++)
        {
            counter--;
			counterText.text = ""+(counter + 1);
            yield return new WaitForSeconds(1);
        }
        /*  jsC.move(0, 0);
          jsC.move(1, 0);
          jsC.move(2, 0);
          jsC.move(3, 0);*/
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

            // Allows Player to go down faster
            if (Input.GetAxis(P1_VERTICAL_AXIS) > 0.5f && !isGrounded)
            {
                _rb.AddForce(-Vector2.up * 60);
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
       // Debug.Log("Stop " + stopJump + "IsJ" + isJumping);
        // Default jump
        if (isJumping)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpStrength);
            isJumping = false;
            isGrounded = true;
			playeraudio.clip = jump;
			playeraudio.Play ();
        } 

  

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Collision Detection for Falling
		if (collision.gameObject.tag == "Win")
		{
			playeraudio.clip = winsound;
			playeraudio.Play ();
			StartCoroutine ("Wait");
		
		}
		else if (collision.gameObject.tag == "DeathBoundary")
        {
            isAlive = false;
			playeraudio.clip = dyingsfx;
			playeraudio.Play ();
            StartCoroutine(OnDeath());        
        }

		else if (collision.gameObject.tag == "Collectible")
		{

			hasSeed++;

			playeraudio.clip = obtainseed;
			playeraudio.Play ();


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
        yield return new WaitForSeconds(1.7f);
        isGrounded = true;
		gameObject.GetComponent<SpriteRenderer> ().enabled = true;
		corpse = GameObject.FindGameObjectWithTag ("corpse");
		GameObject.Destroy (corpse);
		gameObject.GetComponent<SpriteRenderer> ().sprite = normalPlayer;
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
	IEnumerator Wait()
	{
		//scene delay
		yield return new WaitForSeconds (2f);
		SceneManager.LoadScene ("YouWin");
	}

}
