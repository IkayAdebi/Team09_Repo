using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatDeath : MonoBehaviour
{
	public int lifetime;
	public bool doIDie;
    private FloorController jsC;

    IEnumerator shake()
    {

    //    jsC.move(2, 9);
    //    jsC.move(3, 9);
        yield return new WaitForSeconds(0.1f);
   //     jsC.move(2, 7);
   //     jsC.move(3, 7);
        yield return new WaitForSeconds(0.1f);
   //     jsC.move(2, 4);
   //     jsC.move(3, 4);
        yield return new WaitForSeconds(0.1f);
     //   jsC.move(2, 0);
    //    jsC.move(3, 0);
        yield return new WaitForSeconds(0.1f);
      //  jsC.move(2, 5);
     //   jsC.move(3, 5);
        yield return new WaitForSeconds(0.1f);
     //   jsC.move(2, 10);
      //  jsC.move(3, 10);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
            if (other.gameObject.tag == "Player")
            {
            }

    }

    IEnumerator deathCounter()
	{
		yield return new WaitForSeconds(lifetime);
		gameObject.transform.position = new Vector3(-100, 100, 100);
		gameObject.SetActive(false);
	}

	// Use this for initialization
	void Start () {
		doIDie = true;
	}

	// Update is called once per frame
	void Update () {
		if (doIDie)
		{
			doIDie = false;
			StartCoroutine("deathCounter");
		}
	}
}
