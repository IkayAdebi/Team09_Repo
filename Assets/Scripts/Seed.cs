using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour {






    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
			
			StartCoroutine("timeTilDeath");
        }
    }



	IEnumerator timeTilDeath() {
		yield return new WaitForSeconds(1);
		Destroy(gameObject);

	}


}
