using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningStrike : MonoBehaviour {

    private FloorController jsC;
    // Use this for initialization
    void Start () {
	    StartCoroutine("Fizzle");
	}

	// Update is called once per frame
	void Update () {
		Destroy (gameObject);
	}

	IEnumerator Fizzle()
    {
        jsC.move(0, 5);
        jsC.move(1, 5);
        jsC.move(2, 5);
        jsC.move(3, 5);
        yield return new WaitForSeconds(0.2f);
        jsC.move(0, 10);
        jsC.move(1, 10);
        jsC.move(2, 10);
        jsC.move(3, 10);
        yield return new WaitForSeconds(0.2f);
        jsC.move(0, 0);
        jsC.move(1, 0);
        jsC.move(2, 0);
        jsC.move(3, 0);
        yield return new WaitForSeconds(0.2f);
        jsC.move(0, 10);
        jsC.move(1, 10);
        jsC.move(2, 10);
        jsC.move(3, 10);
    }
}
