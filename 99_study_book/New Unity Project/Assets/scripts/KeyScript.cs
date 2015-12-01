using UnityEngine;
using System.Collections;

public class KeyScript : MonoBehaviour {
	Vector3 vec;

	// Use this for initialization
	void Start () {
		vec = new Vector3 (0.1f, 0.1f, 0.1f); 	
	}
	
	// Update is called once per frame
	void Update () {
		OperateKey ();
		CubeRotate ();
	}

	private void  OperateKey() {
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.Translate(transform.forward * 0.1f);
		}
		
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.Translate(transform.forward * -0.1f);
		}
		
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate(transform.right * 0.1f);
		}
		
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate(transform.right * -0.1f);
		}
	}

	private void CubeRotate() {
		if (Input.GetMouseButton (0)) {
			transform.Rotate(vec);
		}
	}
}
