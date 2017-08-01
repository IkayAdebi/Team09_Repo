using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CounterAndVariables : MonoBehaviour {
    public static int shipHealth = 100;
    public static int playerEnergy = 100;
    public static int fire1Time = 0;
   // public static int fire2Time = 0;
    private int fire1Counter = 0;
    private int winCounter = 0;
    //  private int fire2Counter = 0;
    public GameObject fireMonitor;
    public GameObject noFireMonitor;
    public GameObject fireMonitorUse;
    public GameObject noFireMonitorUse;

    // Use this for initialization
    void Start () {
        fireMonitorUse = Instantiate(fireMonitor);
        noFireMonitorUse = Instantiate(noFireMonitor);
        fireMonitorUse.GetComponent<SpriteRenderer>().enabled = false;
        noFireMonitorUse.GetComponent<SpriteRenderer>().enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        winCounter++;
        if (winCounter < 3600)
        {
            if (shipHealth > 0)
            {
                fire1Counter++;
                Debug.Log(fire1Counter);
                // fire2Counter++;
                if (fire1Counter > 300)
                {
                    noFireMonitorUse.GetComponent<SpriteRenderer>().enabled = false;
                    fireMonitorUse.GetComponent<SpriteRenderer>().enabled = true;
                    fire1Time++;
                    if (fire1Time > 3000)
                    {
                        //shipHealth = shipHealth - 5;
                    }
                }
                /* if (fire2Counter > 1000)
                 {
                     fire2Time++;
                     if (fire2Time > 3000)
                     {
                         shipHealth = shipHealth - 5;
                     }
                 }*/
            }
            else
            {
                SceneManager.LoadScene("GameOver");
            }
        }
        else
        {
            SceneManager.LoadScene("YouWin");
        }
    }
}
