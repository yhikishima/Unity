using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	StartController start;
	private GameObject enemyPrefab;

	// Use this for initialization
	void Start () {
		enemyPrefab = (GameObject)Resources.Load ("Prefabs/Enemies/Robot_Enemy01");

		GameObject StartObj = GameObject.FindWithTag ("start");
		start = StartObj.GetComponent<StartController> ();
		StartCoroutine( EnemyCoroutine() );
	}

	// Update is called once per frame
	void Update () {

	}

	private IEnumerator EnemyCoroutine() {
		while (true) {
			if (!start.openStart) {
				yield return null;
			} else {
				var grounds = GameObject.FindGameObjectsWithTag ("ground");
				// var groundPosition = .transform.position;

				Instantiate(enemyPrefab, grounds[0].transform.position, enemyPrefab.transform.rotation);
				yield return new WaitForSeconds(5.0f);
			}
		}
	}
}
