using UnityEngine;
using System.Collections;

public class WaeponAttack : MonoBehaviour {
	Animator animator;
	GameObject Nyago;
	Robot robot;

	// Use this for initialization
	void Start () {
		Nyago = GameObject.FindWithTag ("Player");
		animator = Nyago.GetComponent<Animator>();
		robot = Nyago.GetComponent<Robot>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnCollisionEnter(Collision collision) {
		if (collision.transform.CompareTag ("Player")) {
			Application.LoadLevel("Main"); // シーンの名前かインデックスを指定
			robot.ToEnd ();
		}
	}
}
