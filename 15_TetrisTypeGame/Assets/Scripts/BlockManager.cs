using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlockManager : MonoBehaviour {
	float spd = 0.1f;


	void Start () {

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
		transform.position = transformPos;
	}
}
