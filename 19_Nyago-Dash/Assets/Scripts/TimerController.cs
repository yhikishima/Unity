using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerController : MonoBehaviour {
	private Text secondText;
	private Text pointText;
	private Text minutesText;
	
	private float minutes;
	private float second;
	private float point;

	GameObject Nyago;
	Robot robot;

	StartController start;

	bool timeStop = false;
	float startTime;

	// Use this for initialization
	void Start () {
		GameObject MinutesObj = transform.FindChild ("Minutes").gameObject;
		GameObject SecondObj = transform.FindChild ("Second").gameObject;
		GameObject PointObj = transform.FindChild ("Point").gameObject;
		minutesText = MinutesObj.GetComponent<Text> ();
		secondText = SecondObj.GetComponent<Text> ();
		pointText = PointObj.GetComponent<Text> ();

		Nyago = GameObject.FindWithTag ("Player");
		robot = Nyago.GetComponent<Robot>();

		GameObject StartObj = GameObject.FindWithTag ("start");
		start = StartObj.GetComponent<StartController> ();
		startTime = Time.time;
	}

	// Update is called once per frame
	void Update () {
		if (!timeStop && start.isStart) {
			SetTime ();
		}
	}
	
	public void SetStartTime() {
		startTime = Time.time;
	}
	
	public float[] GetCurrentTime() {
		float[] timeArray = new float[3]{minutes, second, point};

		return timeArray;
	}

	private void SetTime() {
		float currentTime = Time.time;
		currentTime = currentTime - startTime;

		second = Mathf.Floor (currentTime);
		point = Mathf.Floor ((currentTime - second) * 100);

		if (second < 10) {
			secondText.text = "0" + (second).ToString ();

		} else if (second < 60) {
			secondText.text = (second).ToString ();

		// 分の設定
		} else {
			minutes = Mathf.Floor (second / 60);
			second = Mathf.Floor(((second / 60) - minutes) * 100);

			if (minutes < 10) {
				minutesText.text = "0" + (minutes).ToString ();
			} else {
				minutesText.text = (minutes).ToString ();
			}

			if (second < 10) {
				secondText.text = "0" + (second).ToString ();
			} else {
				secondText.text = (second).ToString ();
			}
		}

		// ミリ秒設定
		if (point < 10) {
			pointText.text = "0" + (point).ToString();
		} else {
			pointText.text = (point).ToString();
		}

		if (robot.isDie) {
			timeStop = true;
		}
	}
}
