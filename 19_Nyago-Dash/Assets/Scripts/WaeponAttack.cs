using UnityEngine;
using System.Collections;

public class WaeponAttack : MonoBehaviour {
	Animator animator;
	GameObject Nyago;
	Robot robot;
	WaeponController waeponController;

	// Use this for initialization
	void Start () {
		Nyago = GameObject.FindWithTag ("Player");
		animator = Nyago.GetComponent<Animator>();
		robot = Nyago.GetComponent<Robot>();

		GameObject Weapons = GameObject.FindWithTag ("weapons");
		waeponController = Weapons.GetComponent<WaeponController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnCollisionEnter(Collision collision) {
		if (collision.transform.CompareTag ("Player")) {
			robot.ToEnd ();
			waeponController.DestroyAllSpear ();
		}
	}
}
