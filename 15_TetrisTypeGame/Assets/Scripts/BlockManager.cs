using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlockManager : MonoBehaviour {
	float spd = 0.1f;
	float blockH;


	void Start () {
		blockH = Screen.width;

		Debug.Log ("aaa");
		Debug.Log (blockH);

//		Vector3 transformPos = transform.position;

	}

	void Update () {
		Vector3 transformPos = transform.position;

		if (Input.GetKey("right")) {
			Debug.Log ("right");
			transformPos.x += spd;
		}
		if (Input.GetKey("left")) {
			transformPos.x -= spd;
		}
		if (Input.GetKey("up")) {
			transformPos.z += spd;
		}
		if (Input.GetKey("down")) {
			transformPos.z -= spd;
		}

		transformPos.y -= 0.1f;
		transform.position = transformPos;
	}

	void OnCollisionEnter(Collision col) {
		Debug.Log ("落ちた");
		Rigidbody rb = GetComponent<Rigidbody>();
		rb.velocity = Vector3.zero;
	}
}
