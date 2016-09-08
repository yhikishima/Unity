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

		} catch (System.NullReferenceException e) {}

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
			Rigidbody rigidbody = GetComponent<Rigidbody>();
			rigidbody.angularVelocity = Vector3.zero;
			rigidbody.velocity = Vector3.zero;
		}
	}

	void OnTriggerStay(Collider collider) {

	}

	void OnTriggerExit(Collider collider) {
		if (collider.gameObject.tag == "Player") {
//			collider.gameObject.GetComponent<Renderer>().material.color = new Color(0,1f,0,0.5f);
			Rigidbody rigidbody = GetComponent<Rigidbody>();
			Vector3 v = rigidbody.velocity;
			v.x *= 10;
			v.y *= 10;
			v.z *= 10;
			rigidbody.velocity = v;
			Vector3 v2 = rigidbody.angularVelocity;
			v2.x *= 10;
			v2.y *= 10;
			v2.z *= 10;
			rigidbody.angularVelocity = v2;
		}
	}
}
