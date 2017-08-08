using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earthquake_Result : MonoBehaviour {

    private float normalSpeed;
    private float normalJump;
    public bool enable;
    public float effectTime;
    public float deathTime;
    public GameObject snow_effect;
    public GameObject player;
    private Player playerScript;
    public int changeRate;
    private bool dontDiePlease = true;
    public GameObject wp;
    public WeatherPlayer wpScript;
    private FloorController jsC;

    /*IEnumerator startQuake()
    {
        playerScript.stopJump = true;
        playerScript.isJumping = false;
        playerScript.flip = true;
        yield return new WaitForSeconds(effectTime);
        playerScript.stopJump = false;
        playerScript.lowerSpeed = true;
        playerScript.flip = false;
        gameObject.transform.position = new Vector3(-100, 100, 100);
        gameObject.SetActive(false);
        dontDiePlease = false;
        /* This is the old effect. I want to keep all the needed variables in case we want to do something similar later.
        playerScript.increaseSpeed = true;
        playerScript.moveSpeed = player.GetComponent<Player>().moveSpeed * changeRate;
        yield return new WaitForSeconds(gapTime);
        playerScript.increaseSpeed = false;
        playerScript.moveSpeed = player.GetComponent<Player>().moveSpeed / changeRate;
        playerScript.flip = true;
        yield return new WaitForSeconds(gapTime);
        playerScript.flip = false;
        playerScript.stopJump = true;
        playerScript.isJumping = false;
        yield return new WaitForSeconds(gapTime);
        playerScript.stopJump = false;
        playerScript.lowerSpeed = true;
        playerScript.moveSpeed = player.GetComponent<Player>().moveSpeed / changeRate;
        yield return new WaitForSeconds(gapTime);
        playerScript.lowerSpeed = false;
        playerScript.moveSpeed = player.GetComponent<Player>().moveSpeed * changeRate;
        playerScript._jumpStrength = player.GetComponent<Player>()._jumpStrength * changeRate;
        yield return new WaitForSeconds(gapTime);
        playerScript._jumpStrength = player.GetComponent<Player>()._jumpStrength / changeRate;
        playerScript.moveRestrict = true;
        yield return new WaitForSeconds(gapTime);
        playerScript.moveRestrict = false;
        playerScript._jumpStrength = player.GetComponent<Player>()._jumpStrength / changeRate;
        yield return new WaitForSeconds(gapTime);
        playerScript._jumpStrength = player.GetComponent<Player>()._jumpStrength * changeRate;
        gameObject.transform.position = new Vector3(-100, 100, 100);
        gameObject.SetActive(false);
        dontDiePlease = false;
      }*/

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
        dontDiePlease = true;
        yield return new WaitForSeconds(deathTime);
        gameObject.transform.position = new Vector3(-100, 100, 100);
        dontDiePlease = false;
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
        dontDiePlease = false;
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
        if (!dontDiePlease)
        StartCoroutine("toDeath");
        if (wpScript.inCheck)
        {
            gameObject.transform.position = new Vector3(-100, 100, 100);
            gameObject.SetActive(false);
            dontDiePlease = false;
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
            if (other.gameObject.tag == "Player")
            {
            playerScript.stopJump = true;
            StartCoroutine("waitFlip", true);
            Player.isGrounded = true;
            StartCoroutine("quakeShake");
        }
           

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && gameObject.activeSelf)
        {
            playerScript.stopJump = false;
            StartCoroutine("waitFlip", false);
            Player.isGrounded = true;
            StopCoroutine("quakeShake");
         //   jsC.move(0, 10);
         //   jsC.move(1, 10);
         //   jsC.move(2, 10);
         //   jsC.move(3, 10);
        }

    }

    IEnumerator waitFlip(bool a)
    {
        yield return new WaitForSeconds(.2f);
        if (a)
        {
            playerScript.flip = true;
        }
        else
        {
            playerScript.flip = false;
        }
    }
}
