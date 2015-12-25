using UnityEngine;
using System.Collections;

public class RigidBodyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject cube = GameObject.Find("Cube2");
		Debug.Log(cube);

		Rigidbody rigidbody = GetComponent<Rigidbody> ();

		cube.transform.Rotate (1f, -1f, -1f);

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

	//  collider test, Atack to Cube so Cube color is yello 
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name != "Plane" ) {
			collision.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
		}
	}
}
