using UnityEngine;
using System.Collections;

public class StartController : MonoBehaviour {
	public bool isStart = false;
	public bool openStart = false;
	
	TimerController timer;

	// Use this for initialization
	void Start () {
			GameObject TimerObj = GameObject.FindWithTag ("timer");
			timer = TimerObj.GetComponent<TimerController>();
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
		timer.SetStartTime();
		openStart = true;
	}
}
