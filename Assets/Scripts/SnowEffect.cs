using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowEffect : MonoBehaviour {

    public GameObject playerOne;
    private Player playerScript;
    public int lifetime;
    public int divisionFactor;
    private float initialState;
	AudioSource snowy;

	// Use this for initialization
	void Start () {
        playerScript = playerOne.GetComponent < Player >();
        initialState = playerScript.moveSpeed;
		snowy = gameObject.GetComponent<AudioSource> ();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.P))
        {
            StartCoroutine("timeTilDeath");
        }
    }

    IEnumerator timeTilDeath()
    {
        for (int c = 0; c < lifetime + 1; c++)
        {
            yield return new WaitForSeconds(1);
        }
        playerScript.moveSpeed = initialState;
        gameObject.SetActive(false);
        transform.position = new Vector3(-100, -100, -100);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            playerScript.moveSpeed = initialState / divisionFactor;
        }
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerScript.moveSpeed = initialState;
        }
    }
}
