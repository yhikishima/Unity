using UnityEngine;
using System.Collections;

public class GoalController : MonoBehaviour {
	GameObject Nyago;
	Robot robot;

	// Use this for initialization
	void Start () {
		Nyago = GameObject.FindWithTag ("Player");
		robot = Nyago.GetComponent<Robot>();
	}

	// Update is called once per frame
	void Update () {

	}

	private void OnCollisionEnter(Collision col) {
		if (col.transform.CompareTag ("Player")) {
			robot.ToEnd ();
		}
	}
}
