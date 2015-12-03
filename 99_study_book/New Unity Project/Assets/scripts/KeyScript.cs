using UnityEngine;
using System.Collections;

public class KeyScript : MonoBehaviour {
	Vector3 vec;
	Vector3 stdSize;
	Vector3 smlSize;
	RaycastHit hit;
	int counter = 0;
	bool flg = false;

	// Use this for initialization
	void Start () {
		vec = new Vector3 (0.1f, 0.1f, 0.1f);
		stdSize = new Vector3 (1f, 1f, 1f);
		smlSize = new Vector3 (0.5f, 0.5f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		OperateKey ();
		CubeRotate ();
		MouseButtonDown ();
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

	private void MouseButtonDown() {
		if (flg) {
			if (counter <= 0) {

			}
		}

		if (Input.GetMouseButtonDown (0)) {
			Vector3 pos = Input.mousePosition;
			pos.z = 3.0f;
			Vector3 newpos = Camera.main.ScreenToWorldPoint(pos);
			transform.position = newpos;
		}
	}
}
