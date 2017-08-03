using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earthquake_Result : MonoBehaviour {

    private float normalSpeed;
    public bool enable;
    public float gapTime;
    public GameObject snow_effect;
    public GameObject player;
    private Player playerScript;

    IEnumerator startQuake()
    {

        playerScript.increaseSpeed = true;
        playerScript.moveSpeed = player.GetComponent<Player>().moveSpeed * 2;
        yield return new WaitForSeconds(gapTime);
        playerScript.increaseSpeed = false;
        playerScript.moveSpeed = player.GetComponent<Player>().moveSpeed / 2;
        //flip left and right
        yield return new WaitForSeconds(gapTime);
        //reset controls
        playerScript.stopJump = true;
        playerScript.isJumping = false;
        yield return new WaitForSeconds(gapTime);
        playerScript.stopJump = false;
        playerScript.lowerSpeed = true;
        playerScript.moveSpeed = player.GetComponent<Player>().moveSpeed / 2;
        yield return new WaitForSeconds(gapTime);
        playerScript.lowerSpeed = false;
        playerScript.moveSpeed = player.GetComponent<Player>().moveSpeed * 2;
        //Flip Direction
        yield return new WaitForSeconds(gapTime);
        //Reset Direction
        //Increase Jump Hight
        yield return new WaitForSeconds(gapTime);
        //Reset Jump Hight
        //Stop Movement
        yield return new WaitForSeconds(gapTime);
        //Renable Movement
        //Decrease Jump Height
        yield return new WaitForSeconds(gapTime);
        //Reset Jump Height
        gameObject.transform.position = new Vector3(-100, 100, 100);
        gameObject.SetActive(false);
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
        enable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (enable)
        {
            enable = false;
            StartCoroutine("startQuake");
        }
    }
}
