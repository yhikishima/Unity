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

	}
}
