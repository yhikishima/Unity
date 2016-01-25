using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Animator))]
public class SampleUnityChanController : MonoBehaviour {
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		anim.SetFloat ("Speed", v);
		anim.SetFloat ("Direction", h);
		anim.SetBool ("jump", false);
		Vector3 vector = new Vector3 (0, 0, v);
		vector = transform.TransformDirection (vector) * 5f;
		transform.localPosition += vector * Time.fixedDeltaTime;
		transform.Rotate (0, h, 0);

		if (Input.GetButtonDown("Jump")) {
			GetComponent<Rigidbody> ().AddForce (Vector3.up);
			anim.SetBool ("Jump", true);
		}
	}
}
