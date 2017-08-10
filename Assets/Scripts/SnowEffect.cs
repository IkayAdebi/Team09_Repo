using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowEffect : MonoBehaviour {

    public GameObject playerOne;
    private Player playerScript;
    public int divisionFactor;
    private float initialState;
	AudioSource snowy;
    public GameObject wp;
    public WeatherPlayer wpScript;
    public int lifetime;
    public bool doIDie;
    private FloorController jsC;

    public GameObject particle;
    public GameObject freeze;

    // Use this for initialization
    void Start () {
		
		playerScript = playerOne.GetComponent < Player >();
        initialState = playerScript.moveSpeed;
        wp = GameObject.Find("Player 2");
        wpScript = wp.GetComponent<WeatherPlayer>();
		snowy = gameObject.GetComponent<AudioSource> ();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.P))
        {
            StartCoroutine("timeTilDeath");
        }
    }

    IEnumerator jostleSnow() {
        while (1 == 1)
        {
           // jsC.move(0, 8);
         //   jsC.move(1, 8);
          //  jsC.move(2, 8);
          //  jsC.move(3, 8);
            yield return new WaitForSeconds(.1f);
            //jsC.move(0, 10);
          //  jsC.move(1, 10);
         //   jsC.move(2, 10);
          //  jsC.move(3, 10);
            yield return new WaitForSeconds(0.9f);
        }

    }

    IEnumerator timeTilDeath()
    {
        for (int c = 0; c < lifetime + 1; c++)
        {
            yield return new WaitForSeconds(1);
        }
    //    jsC.move(0, 10);
 //       jsC.move(1, 10);
     //   jsC.move(2, 10);
     //   jsC.move(3, 10);
        playerScript.moveSpeed = initialState;
        transform.position = new Vector3(-100, -100, -100);
        freeze.transform.position = transform.position;
        freeze.SetActive(false);
        particle.transform.position = transform.position;
        particle.SetActive(false);
        gameObject.SetActive(false);
    }
		
    void OnTriggerStay2D(Collider2D other)
    {
        if (playerScript.lowerSpeed || playerScript.increaseSpeed)
        {
        }
        else {
            if (other.gameObject.tag == "Player" && !wpScript.inCheck)
            {
                StartCoroutine("jostleSnow");
                playerScript.moveSpeed = initialState / divisionFactor;
            }
        }
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (playerScript.lowerSpeed || playerScript.increaseSpeed)
        {
        }
        else
        {
            if (other.gameObject.tag == "Player")
            {
                StopCoroutine("jostleSnow");
            //    jsC.move(0, 10);
             //   jsC.move(1, 10);
            //    jsC.move(2, 10);
            //    jsC.move(3, 10);
                playerScript.moveSpeed = initialState;
            }
        }
    }
}
