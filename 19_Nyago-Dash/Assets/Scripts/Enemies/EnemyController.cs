using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine( EnemyCoroutine() );
	}

	// Update is called once per frame
	void Update () {

	}

	private IEnumerator EnemyCoroutine() {
		GameObject enemyPrefab = (GameObject)Resources.Load ("Prefabs/Enemies/Robot_Enemy01");
		// Instantiate(enemyPrefab);
		while (true) {
			Instantiate(enemyPrefab, transform.position, enemyPrefab.transform.rotation);
			yield return new WaitForSeconds(3.0f);
		}
	}
}
