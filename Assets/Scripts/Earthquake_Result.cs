using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earthquake_Result : MonoBehaviour {

    private float normalSpeed;
    private float normalJump;
    public bool enable;
    public float gapTime;
    public GameObject snow_effect;
    public GameObject player;
    private Player playerScript;
    public int changeRate;

    IEnumerator startQuake()
    {

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
