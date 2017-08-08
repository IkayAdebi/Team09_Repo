using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earthquake_Result : MonoBehaviour {

    private float normalSpeed;
    private float normalJump;
    public bool enable;
    public float deathTime;
    public GameObject snow_effect;
    public GameObject player;
    private Player playerScript;
    public int changeRate;
    public GameObject wp;
    public WeatherPlayer wpScript;
    private FloorController jsC;
    public bool react;
    private bool d = false;
    

    IEnumerator quakeShake()
    {
        while (1 == 1)
        {
            int c = (int) Random.value * 4;
            float i = Random.value * 10;
            //jsC.move(c, i);
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator toDeath()
    {
        yield return new WaitForSeconds(deathTime);
        gameObject.transform.position = new Vector3(-100, 100, 100);
        playerScript.stopJump = false;
        playerScript.flip = false;
        // jsC.move(0, 10);
        //jsC.move(1, 10);
        //jsC.move(2, 10);
        //jsC.move(3, 10);
        gameObject.SetActive(false);
        Player.isGrounded = true;
    }

    // Use this for initialization
    void Start()
    {
        playerScript = player.GetComponent<Player>();
        if (snow_effect.activeSelf)
        {
            normalSpeed = player.GetComponent<Player>().moveSpeed * snow_effect.GetComponent<SnowEffect>().divisionFactor;
        }
        else
        {
            normalSpeed = player.GetComponent<Player>().moveSpeed;
        }
        normalJump = player.GetComponent<Player>()._jumpStrength;
        enable = true;
        wp = GameObject.Find("Player 2");
        wpScript = wp.GetComponent<WeatherPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        playerScript.moveRestrict = false;
        StartCoroutine("toDeath");
        if (wpScript.inCheck)
        {
            gameObject.transform.position = new Vector3(-100, 100, 100);
            gameObject.SetActive(false);
            playerScript.stopJump = false;
            playerScript.flip = false;
            Player.isGrounded = true;
            //jsC.move(0, 10);
            //jsC.move(1, 10);
            //jsC.move(2, 10);
           // jsC.move(3, 10);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        playerScript.stopJump = true;
        Player.isGrounded = true;
        if (other.gameObject.tag == "Player")
        {
            playerScript.stopJump = true;
            if (react) { 
                playerScript.flip = true;
                StartCoroutine("quakeShake");
        }
        }
           

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && gameObject.activeSelf)
        {
            playerScript.stopJump = false;
            Player.isGrounded = true;
            if (react)
            {
            playerScript.flip = false;
            StopCoroutine("quakeShake");
            //   jsC.move(0, 10);
            //   jsC.move(1, 10);
            //   jsC.move(2, 10);
            //   jsC.move(3, 10);
            react = false;
            }
        }

    }

}
