using UnityEngine;
using System.Collections;

public class ParticleScript : MonoBehaviour {
	GameObject[] cubes = new GameObject[4];
	GameObject[] gos = new GameObject[4];

	// Use this for initialization
	void Start () {
		for (int i =0; i < 4; i++) {
			cubes[i] = GameObject.Find ("Cube" + i);
			gos[i] = GameObject.Find ("GameObject" + i);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
