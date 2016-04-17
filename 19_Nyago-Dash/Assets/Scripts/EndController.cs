using UnityEngine;
using System.Collections;

public class EndController : MonoBehaviour {
	private GameObject Nyago;
	private Robot robot;
	private bool openStart = false;
	private StartController start;

	const float blockTop = 172;

	// Use this for initialization
	void Start () {
//		End = GameObject.FindWithTag("end");
		Nyago = GameObject.FindWithTag ("Player");
		robot = Nyago.GetComponent<Robot>();

		GameObject StartObj = GameObject.FindWithTag ("start");
		start = StartObj.GetComponent<StartController> ();
		//		render = GetComponent<Renderer>();
//		End.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		robot = Nyago.GetComponent<Robot>();
		if (robot.isDie) {
			Invoke ("CloseBlock", 3);
		}

		if (openStart) {
			OpenBlock ();
		}
	}

	private void CloseBlock() {
		Vector3 pos = transform.position;
		if (pos.y <= blockTop) {
			return;
		}

		if (pos.y > 300 + blockTop) {
			pos.y -= 1f;
		} else if (pos.y > 200 + blockTop) {
			pos.y -= 10f;
		} else if (pos.y > blockTop) {
			pos.y -= 20f;
		}

		transform.position = pos;
	}

	private void OpenBlock() {
		Vector3 pos = transform.position;
		if (pos.y > 600) {
			start.isStart = true;
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

	public void StartClick() {
		robot.ToStart ();
	}
}
