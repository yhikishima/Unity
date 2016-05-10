using UnityEngine;
using System.Collections;

public class EnemyWalk : MonoBehaviour {
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x + 0.2f, 0, transform.position.z);
	}
}
