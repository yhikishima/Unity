using UnityEngine;
using System.Collections;

public class EnemyWalk : MonoBehaviour {
	// Use this for initialization

	StartController start;
	void Start () {
		GameObject StartObj = GameObject.FindWithTag ("start");
		start = StartObj.GetComponent<StartController> ();
	}

	// Update is called once per frame
	void Update () {
		if (start.openStart) {
			transform.position = new Vector3(transform.position.x + 0.2f, 0, transform.position.z);
		}
	}
}
