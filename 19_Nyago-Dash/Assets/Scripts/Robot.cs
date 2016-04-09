using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour {
	static bool isGoal = false;

	// Use this for initialization
	void Start () {
		setAction ();
	
	}
	
	// Update is called once per frame
	void Update () {
		walkForward ();
		setAction ();
	}

	private void walkForward() {
		if (!isGoal) {
			transform.position = new Vector3(transform.position.x - 0.1f, 0f, transform.position.z);			
		}
	}

	private void setAction() {
		// PC向け、キー入力
		if (Input.GetKey("up")) {
//			transform.position = new Vector3(transform.position.x - 0.1f, 0f, transform.position.z);
		} else if (Input.GetKey("right")) {
			transform.position = new Vector3(transform.position.x, 0f, transform.position.z + 0.1f);
		} else if (Input.GetKey("left")) {
			transform.position = new Vector3(transform.position.x, 0f,  transform.position.z - 0.1f);
		}
	}
}
