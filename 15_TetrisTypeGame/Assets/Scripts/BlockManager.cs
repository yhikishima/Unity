using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlockManager : MonoBehaviour {
	float spd = 0.6f;
	float blockH;
	public bool BlockDropFlg = true;

	void Start () {
		blockH = Screen.width;

		Debug.Log ("aaa");
		Debug.Log (blockH);

		InvokeRepeating("dropBlock", 1, 1);

//		Vector3 transformPos = transform.position;

	}

	void dropBlock () {
		Vector3 transformPos = transform.position;
		if (BlockDropFlg) {
			transformPos.y -= 0.6f;
		}
		transform.position = transformPos;
	}

	void Update () {
		Vector3 transformPos = transform.position;

		if (BlockDropFlg) {
			if (Input.GetKeyDown("right")) {
				transformPos.x += spd;
			}
			if (Input.GetKeyDown("left")) {
				transformPos.x -= spd;
			}

			if (Input.GetKeyDown("down")) {
				transformPos.y -= spd;
			}

			transform.position = transformPos;
		}
	}

	void OnCollisionEnter(Collision col) {
		BlockDropFlg = false;
		Debug.Log ("落ちた");
		Rigidbody rb = GetComponent<Rigidbody>();
//		rb.useGravity = true;
//		rb.velocity = Vector3.zero;
	}
}
