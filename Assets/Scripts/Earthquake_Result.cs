using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earthquake_Result : MonoBehaviour {

    public bool enable;
    public float gapTime;

    IEnumerator startQuake()
    {
        //Speed up player
        yield return new WaitForSeconds(gapTime);
        //reset player speed and think through snow
        //flip left and right
        yield return new WaitForSeconds(gapTime);
        //reset controls
        //disable jump
        yield return new WaitForSeconds(gapTime);
        //re-enable jump
        //slow player all the way up. ALL THE WAY UP
        yield return new WaitForSeconds(gapTime);
        //Reset player speed and think through snow
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
