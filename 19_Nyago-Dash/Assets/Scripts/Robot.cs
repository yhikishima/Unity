using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour {
	public bool isGoal = false;
	public bool isDie = false;

	public float speed = 0.1f;
	
	private bool walkingFlg = false;
	Animator animator;
	StartController start;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		GameObject StartObj = GameObject.FindWithTag ("start");
		start = StartObj.GetComponent<StartController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (start.isStart) {
			if (!walkingFlg) {
				// 初めの一回だけ、遅らせたい
				Invoke ("WalkForward", 2);
				walkingFlg = true;
			} else {
				WalkForward();
			}

			SetAction ();
		}
	}

	private void WalkForward() {
		if (!isGoal && !isDie) {
			transform.position = new Vector3(transform.position.x - speed, 0f, transform.position.z);			
		}
	}

	private void SetAction() {
		// PC向け、キー入力
		if (Input.GetKey("up")) {
//			transform.position = new Vector3(transform.position.x - 0.1f, 0f, transform.position.z);
		} else if (Input.GetKey("right")) {
			transform.position = new Vector3(transform.position.x, 0f, transform.position.z + 0.1f);
		} else if (Input.GetKey("left")) {
			transform.position = new Vector3(transform.position.x, 0f,  transform.position.z - 0.1f);
		}

		// Animation
		if (Input.GetKeyDown("space")) {
			animator.SetBool("Jump", true);
		}
		if (Input.GetKeyUp("space")) {
			animator.SetBool("Jump", false);
		}
		if (start.isStart) {
			animator.SetBool("Run", true);
		}
	}

	public void ToStart() {
		animator.SetBool("Die", false);
		isDie = false;
	}

	public void ToEnd() {
		animator.SetBool("Die", true);
		isDie = true;
	}
}
