using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindEffect : MonoBehaviour {
	AudioSource windy;
    public float windSpeed;
    public int lifetime;
    public GameObject wp;
    public WeatherPlayer wpScript;
//    private FloorController jsC;

    // Use this for initialization
    void Start () {
<<<<<<< HEAD
    //    jsC.move(0, 0);
  //      jsC.move(1, 0);
=======
>>>>>>> b35e7d8248fbc66f1e38f9009823245ab1b45119
		windy = gameObject.GetComponent<AudioSource> ();
        wp = GameObject.Find("Player 2");
        wpScript = wp.GetComponent<WeatherPlayer>();
    }
	
	// Update is called once per frame
	void Update () {
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
<<<<<<< HEAD
//                jsC.disable();
=======

                jsC.move(0, 10);
                jsC.move(1, 10);
>>>>>>> b35e7d8248fbc66f1e38f9009823245ab1b45119
            }

            yield return new WaitForSeconds(1);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        
        Vector2 windVector = new Vector2(-windSpeed, 0);
        if (other.gameObject.tag == "Player")
        {
            //other.gameObject.GetComponent<Rigidbody2D>().velocity = (-transform.right * windSpeed);
            other.gameObject.GetComponent<Rigidbody2D>().drag = 1f;
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(windVector);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player" && !wpScript.inCheck)
        {
            jsC.move(0, 0);
            jsC.move(1, 0);
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Player" && !wpScript.inCheck)
        {
            jsC.move(0, 10);
            jsC.move(1, 10);
        }

    }


}
