using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	StartController start;
	GameObject enemyPrefab;

	// Use this for initialization
	void Start () {
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
				yield return new WaitForSeconds(5.0f);
				var grounds = GameObject.FindGameObjectsWithTag ("ground");

				var enemyRandomNo = Random.Range(0, 4);
				enemyPrefab = (GameObject)Resources.Load ("Prefabs/Enemies/Robot_Enemy0" + (enemyRandomNo+1));

				var position = new Vector3(grounds[0].transform.position.x, enemyPrefab.transform.position.y, enemyPrefab.transform.position.z);

				Instantiate(enemyPrefab, position, enemyPrefab.transform.rotation);
			}
		}
	}
}
