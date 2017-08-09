using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherPlayer : MonoBehaviour
{

    private Rigidbody2D _rb;
    public const string P2_HORIZONTAL_AXIS = "P2_Horizontal";
    public const string P2_VERTICAL_AXIS = "P2_Vertical";

    public const string P2_ABILITY_CHANGE = "RightTrigger";
    public const string P2_ABILITY_USE = "Button_A";

    private bool isTriggerDown = false;

    private float _moveSpeed = .2f;

    private List<string> weatherChoose = new List<string>();
    //Order 0: Wind 1: Snow 2: Lightning 3: Earthquake 4: Fire
    private int weatherIndex = 0;
    private List<string> currentVDirection = new List<string>();
    //Order 0: Up 1: Down 2: Still
    private int vDirectionIndex = 2;
    private List<string> currentHDirection = new List<string>();
    //Order 0: Left 1: Right 2: Still
    private int hDirectionIndex = 2;


    private Sprite useSprite;
    public Sprite windSprite;
    public Sprite snowSprite;
    public Sprite lightningSprite;
    public Sprite earthquakeSprite;
    public Sprite fireSprite;

    public GameObject wind;
	public GameObject lightning;
    public GameObject snow;
    public GameObject earthquake;
    public GameObject fire;

    public float windCounter = 0;
    public float lightningCounter = 0;
    public float snowCounter = 0;
    public float earthquakeCounter = 0;
    public float fireCounter = 0;
    public float windCooldown;
    public float lightningCooldown;
    public float snowCooldown;
    public float earthquakeCooldown;
    public float fireCooldown;

    public bool inCheck;
    private FloorController jsC;   

    IEnumerator countUpWind()
    {
        for (float c = 0; c < windCooldown; c = c + 0.1f)
        {
            windCounter = windCounter + .1f;
            yield return new WaitForSeconds(.1f);
        }
    }

    IEnumerator countUpSnow()
    {
        for (float c = 0; c < snowCooldown; c = c + 0.1f)
        {
            snowCounter = snowCounter + .1f;
            yield return new WaitForSeconds(.1f);
        }
    }

    IEnumerator countUpLightning()
    {
        for (float c = 0; c < lightningCooldown; c = c + 0.1f)
        {
            lightningCounter = lightningCounter + .1f;
            yield return new WaitForSeconds(.1f);
        }
    }

    IEnumerator countUpEarthquake()
    {
        for (float c = 0; c < earthquakeCooldown; c = c + 0.1f)
        {
            earthquakeCounter = earthquakeCounter + .1f;
            yield return new WaitForSeconds(.1f);
        }
    }

    IEnumerator countUpFire()
    {
        for (float c = 0; c < fireCooldown; c = c + 0.1f)
        {
            fireCounter = fireCounter + .1f;
            yield return new WaitForSeconds(.1f);
        }
    }

    // Use this for initialization
    void Start()
    {
      /*  jsC.move(0, 10);
        jsC.move(1, 10);
        jsC.move(2, 10);
        jsC.move(3, 10);*/

        wind.SetActive(false);
        weatherChoose.Add("Wind");
        weatherChoose.Add("Snow");
        weatherChoose.Add("Lightning");
        weatherChoose.Add("Earthquake");
        weatherChoose.Add("Fire");

        currentVDirection.Add("Up");
        currentVDirection.Add("Down");
        currentHDirection.Add("Left");
        currentHDirection.Add("Right");
        currentVDirection.Add("Still");
        currentHDirection.Add("Still");
        windCounter = windCooldown;
        snowCounter = snowCooldown;
        lightningCounter = lightningCooldown;
        earthquakeCounter = earthquakeCooldown;
        fireCounter = fireCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        inputChecker();
        spriteChanger();
        refreshSprite();
        movementCode();
    }

    public void inputChecker()
    {
        if ((Input.GetKeyDown(KeyCode.L) || Input.GetAxis(P2_ABILITY_CHANGE) > 0.4f) && !isTriggerDown)
        {
            weatherIndex++;
            if (weatherIndex == 3)
            {
                weatherIndex = 0;
            }

            isTriggerDown = true;
        }

        if (Input.GetAxis(P2_ABILITY_CHANGE) < 0.1f)
        {
            isTriggerDown = false;
        }

        Vector3 spawnPoint = new Vector3(transform.position.x, transform.position.y - 4, 0);
        if (windCounter == 0)
        {
            StartCoroutine("countUpWind");
        }
        if (snowCounter == 0)
        {
            StartCoroutine("countUpSnow");
        }
        if (lightningCounter == 0)
        {
            StartCoroutine("countUpLightning");
        }
        if (earthquakeCounter == 0)
        {
            StartCoroutine("countUpEarthquake");
        }
        if (fireCounter == 0)
        {
            StartCoroutine("countUpFire");
        }

        if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown(P2_ABILITY_USE))
        {
            if (weatherChoose[weatherIndex] == "Wind")
            {

                if (windCounter >= windCooldown)
                {
                  //  shaker.beginWind();
                    wind.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                    wind.SetActive(true);
                    windCounter = 0;
                }
            }
            else if (weatherChoose[weatherIndex] == "Snow")
            {
                if (snowCounter >= snowCooldown)
                {
                  // shaker.beginSnow();
                    snow.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                    snow.SetActive(true);
                    snowCounter = 0;
                }
            }
            else if (weatherChoose[weatherIndex] == "Lightning")
            {
                if (lightningCounter >= lightningCooldown)
                {
                  //  shaker.beginLightning();
                    lightning.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                    lightningCounter = 0;
					lightning.GetComponent<LightningScript> ().isReady = true;
                    lightning.SetActive(true);
                }
            }
            else if (weatherChoose[weatherIndex] == "Earthquake")
            {
                if (earthquakeCounter >= earthquakeCooldown)
                {
                 //   shaker.beginEarthquake();
                    earthquake.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                    earthquakeCounter = 0;
                    earthquake.SetActive(true);
                }
            }
            else
            {
                if (fireCounter >= fireCooldown)
                {
                  //  shaker.beginFire();
                    fire.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                    fireCounter = 0;
                    fire.SetActive(true);
                }
            }
        }

        if (Input.GetKey(KeyCode.Y) || Input.GetAxis(P2_VERTICAL_AXIS) < 0) { 
            vDirectionIndex = 0;
        }
        else if (Input.GetKey(KeyCode.H) || Input.GetAxis(P2_VERTICAL_AXIS) > 0)
        {
            vDirectionIndex = 1;
        }
        else
        {
            vDirectionIndex = 2;
        }
        if (Input.GetKey(KeyCode.G) || Input.GetAxis(P2_HORIZONTAL_AXIS) < 0)
        {
            hDirectionIndex = 0;
        }
        else if (Input.GetKey(KeyCode.J) || Input.GetAxis(P2_HORIZONTAL_AXIS) > 0)
        {
            hDirectionIndex = 1;
        }
        else
        {
            hDirectionIndex = 2;
        }
    }

    public void spriteChanger()
    {
        if (weatherChoose[weatherIndex] == "Wind")
        {
            useSprite = windSprite;
        }
        else if (weatherChoose[weatherIndex] == "Snow")
        {
            useSprite = snowSprite;
        }
        else if (weatherChoose[weatherIndex] == "Lightning")
        {
            useSprite = lightningSprite;
        }
        else if (weatherChoose[weatherIndex] == "Earthquake")
        {
            useSprite = earthquakeSprite;
        }
        else
        {
            useSprite = fireSprite;
        }
    }

    public void movementCode()
    {
        /* if (transform.position.x - cam.transform.position.x > camWidth)
         {
             transform.position = new Vector3(camWidth + cam.transform.position.x, transform.position.y, 0);
         }
         else if (transform.position.x - cam.transform.position.x < camWidth)
         {
             transform.position = new Vector3(0 + cam.transform.position.x, transform.position.y, 0);
         }
         if (transform.position.y - cam.transform.position.y > camHeight)
         {
             transform.position = new Vector3(transform.position.x, camHeight + cam.transform.position.y, 0);
         }
         else if (transform.position.y - cam.transform.position.y < camHeight)
         {
             transform.position = new Vector3(transform.position.x, 0 + cam.transform.position.y, 0);
         }*/

        if (currentVDirection[vDirectionIndex] == "Up")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + (_moveSpeed), 0);
        }
        else if (currentVDirection[vDirectionIndex] == "Down")

        {
            transform.position = new Vector3(transform.position.x, transform.position.y - (_moveSpeed), 0);
        }
        if (currentHDirection[hDirectionIndex] == "Left")
        {
            transform.position = new Vector3(transform.position.x - (_moveSpeed), transform.position.y, 0);
        }
        else if (currentHDirection[hDirectionIndex] == "Right")
        {
            transform.position = new Vector3(transform.position.x + (_moveSpeed), transform.position.y, 0);
        }

        // Check Map boundaries
        if (transform.position.x > 83)
        {
            transform.position = new Vector3(83, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -83)
        {
            transform.position = new Vector3(-83, transform.position.y, transform.position.z);
        }

        if (transform.position.y > 13.5f)
        {
            transform.position = new Vector3(transform.position.x, 13.5f, transform.position.z);
        }

        if (transform.position.y < -13.5f)
        {
            transform.position = new Vector3(transform.position.x, -13.5f, transform.position.z);
        }
    }

    public void refreshSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = useSprite;

        // Flip Sprite
        if (Input.GetKeyDown(KeyCode.O))
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }
}
