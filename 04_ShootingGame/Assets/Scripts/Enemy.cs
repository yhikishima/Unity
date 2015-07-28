using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	Spaceship spaceship;

	// Use this for initialization
	void Start () {
		spaceship = GetComponent<Spaceship>();
		spaceship.Move (transform.up * -1);
	}

}
