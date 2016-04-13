using UnityEngine;
using System.Collections;

public class StartController : MonoBehaviour {
	public bool isStart = false;
	private bool openStart = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (openStart) {
			Vector3 pos = transform.position;
			if (pos.y > 600) {
				isStart = true;
				return;
			}

			if (pos.y < 200) {
				pos.y += 1f;
			} else if (pos.y < 400) {
				pos.y += 10f;
			} else if (pos.y >= 400) {
				pos.y += 20f;
			}

			transform.position = pos;
		}
	}

	public void StartClick() {
		openStart = true;
	}
}
