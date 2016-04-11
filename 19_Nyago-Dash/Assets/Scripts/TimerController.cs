using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerController : MonoBehaviour {
	GameObject SecondObj;

	// Use this for initialization
	void Start () {
		SecondObj = transform.FindChild ("Second").gameObject;	
	}
	
	// Update is called once per frame
	void Update () {
		float currentTime = Time.time;

		float displayTime = Mathf.Floor (currentTime * 100);

		float Second = Mathf.Floor (currentTime);
		Text secondText = SecondObj.GetComponent<Text> ();
		if (Second < 10) {
			secondText.text = "0" + (Second).ToString();
		} else {
			secondText.text = (Second).ToString();			
		}

	}
}
