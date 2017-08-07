using UnityEngine;
using System.Collections;

public class earthquakeController : MonoBehaviour
{
	
		public int moveCount;
		public float spawnWait;
		public float startWait;
		public float waveWait;
		private FloorController jsC;
		float timer;
		private IEnumerator coroutine;

		// Use this for initialization
		void Start ()
		{
				timer = 0.0f;
				coroutine = SpawnMove ();
				jsC = this.gameObject.GetComponent<FloorController> ();
				jsC.enable ();
				jsC.fullVoltage ();
				StartCoroutine (coroutine);
		}
	
		// Update is called once per frame
		void Update ()
		{
				timer += Time.deltaTime;

				if (timer >= 30.0f) {
						//	Debug.Log ("stop");
						StopCoroutine (coroutine);
						jsC.disable ();
				}

		}
	
		IEnumerator SpawnMove ()
		{
				yield return new WaitForSeconds (startWait);
				while (true) {
						for (int i = 0; i < moveCount; i++) {
								jsC.move (Random.Range (0, 3), Random.Range (0F, 9.0F));
								yield return new WaitForSeconds (spawnWait);
						}
						yield return new WaitForSeconds (waveWait);
				}
		}
}
