using UnityEngine;
using System.Collections;

public class SampleUnityChanTrigger : MonoBehaviour {
	Color oldcolor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		oldcolor = collider.GetComponent<Renderer> ().material.color;
		collider.GetComponent<Renderer> ().material.color = Color.magenta;

	}

	void OnTriggerExit(Collider collider) {
		collider.GetComponent<Renderer> ().material.color = oldcolor;
	}
}
