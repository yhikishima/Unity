using UnityEngine;
using System.Collections;

public class Rigidscript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.UpArrow)) {
			transform.GetComponent<Rigidbody>().AddForce(0,0,1);
		}
		if (Input.GetKey(KeyCode.DownArrow)) {
			transform.GetComponent<Rigidbody>().AddForce(0,0,-1);
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			transform.GetComponent<Rigidbody>().AddForce(1,0,0);
		}
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.GetComponent<Rigidbody>().AddForce(-1,0,0);
		}

		Vector3 pos = transform.position;
		pos.y += 2.5f;
		pos.z -= 3f;
		GameObject camera = GameObject.Find ("Main Camera");
		camera.transform.position = pos;
	}
}
