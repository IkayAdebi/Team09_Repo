using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindEffect : MonoBehaviour {
	AudioSource windy;
    public float windSpeed;
    public int lifetime;
    public GameObject wp;
    public WeatherPlayer wpScript;
    private FloorController jsC;
    private Vector2 windVector;

    public int windDirection;

    // Use this for initialization
    void Start ()
    {
        windVector = new Vector2();

        //    jsC.move(0, 0);
        //      jsC.move(1, 0);
        windDirection = 2;

		windy = gameObject.GetComponent<AudioSource> ();
        wp = GameObject.Find("Player 2");
        wpScript = wp.GetComponent<WeatherPlayer>();
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (windDirection == 1)
        {
            Debug.Log(1);
            windVector = new Vector2(windSpeed, 0);
            gameObject.GetComponent<BoxCollider2D>().offset.Set(2.5f, 0);
        }
        else
        {
            Debug.Log(2);
            windVector = new Vector2(-windSpeed, 0);
            gameObject.GetComponent<BoxCollider2D>().offset.Set(-2.5f, 0);
        }
        StartCoroutine("timeTilDeath");
    }

    IEnumerator timeTilDeath()
    {
        for(int c = 0; c < lifetime + 1; c++)
        {
            if(c == lifetime)
            {
                gameObject.SetActive(false);
                transform.position = new Vector3 (-100, -100, -100);
                //jsC.move(0, 10);
               // jsC.move(1, 10);
                //jsC.disable();
                //jsC.move(0, 10);
               // jsC.move(1, 10);
             //   jsC.move(0, 10);
               // jsC.move(1, 10);

            }

            yield return new WaitForSeconds(1);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {


        if (other.gameObject.tag == "Player" && other.gameObject.name != "Ground")
        {
            //other.gameObject.GetComponent<Rigidbody2D>().velocity = (-transform.right * windSpeed);
            if (other.gameObject.name != "Ground")
            {
                other.gameObject.GetComponent<Rigidbody2D>().drag = 1f;
            }

            if (other.gameObject.name != "Ground")
            {
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(windVector);
            }
        }
       

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player" && !wpScript.inCheck)
        {
           // jsC.move(0, 0);
           // jsC.move(1, 0);
       //     jsC.move(0, 0);
        //    jsC.move(1, 0);
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Player" && !wpScript.inCheck)
        {
         //   jsC.move(0, 10);
            //jsC.move(1, 10);
          //  jsC.move(0, 10);
           // jsC.move(1, 10);
        }

    }


}
