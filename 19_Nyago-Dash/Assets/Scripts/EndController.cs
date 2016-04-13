using UnityEngine;
using System.Collections;

public class EndController : MonoBehaviour {
	GameObject Nyago;
	Robot robot;
	GameObject End;
	Renderer render;

	// Use this for initialization
	void Start () {
		End = GameObject.FindWithTag("end");
		Nyago = GameObject.FindWithTag ("Player");
		robot = Nyago.GetComponent<Robot>();
		render = GetComponent<Renderer>();
		End.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (robot.isDie) {
			End.SetActive(true);
		}
	}
}
