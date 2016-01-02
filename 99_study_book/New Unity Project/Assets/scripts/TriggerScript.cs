using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject cube = GameObject.Find ("Cube");
		cube.GetComponent<Renderer> ().material.color = new Color (1f, 0,0,0.5f);
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject cube = GameObject.Find ("Cube");
		Rigidbody rigidbody = GetComponent<Rigidbody> ();

		try {
			cube.transform.Rotate(1f, -1f, -1f);

		} catch {}

		if (Input.GetKey(KeyCode.LeftArrow)) {
			rigidbody.AddForce(new Vector3(-1f, 0, 1f)); // To left roll
		}
		
		if (Input.GetKey(KeyCode.RightArrow)) {
			rigidbody.AddForce (new Vector3(1f, 0, -1f)); // TO right roll
		}
		
		if (Input.GetKey(KeyCode.UpArrow)) {
			rigidbody.AddForce (new Vector3(1f, 0, 1f)); // TO top roll
		}
		
		if (Input.GetKey(KeyCode.DownArrow)) {
			rigidbody.AddForce (new Vector3(-1f, 0, -1f)); // TO bottom roll
		}
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.tag == "Player") {
			collider.gameObject.GetComponent<Renderer>().material.color = new Color(0,1f,0,0.5f);
		}
	}

	void OnTriggerStay(Collider collider) {

	}

	void OnTriggerExit(Collider collider) {
		if (collider.gameObject.tag == "Player") {
			collider.gameObject.GetComponent<Renderer>().material.color = new Color(0,1f,0,0.5f);
		}
	}
}
