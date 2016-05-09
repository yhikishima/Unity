using UnityEngine;
using System.Collections;

public class WaeponController : MonoBehaviour {
	public GameObject spear;

	private GameObject spearObj;
	private GameObject weapons;
	private GameObject[] groundLists;
	private GameObject Nyago;
	private Robot robot;

	private StartController start;

	private float speed = 1.0f;
	private float waitingTime = 3.0f;

	// Use this for initialization
	void Start () {
		Nyago = GameObject.FindWithTag ("Player");
		robot = Nyago.GetComponent<Robot>();
		GameObject StartObj = GameObject.FindWithTag ("start");
		start = StartObj.GetComponent<StartController> ();

		InvokeRepeating("FireSpear", waitingTime, waitingTime);
	}

	void Update () {
		if (spearObj) {
			Vector3 tempSpear = spearObj.transform.position;
			tempSpear.x += speed;
			spearObj.transform.position = tempSpear;
		}
	}

	private void FireSpear() {
		if (robot.isDie) {
			return;
		}

		if (!start.isStart) {
			return;
		}

		// GameObject spearObj = GameObject.FindWithTag ("spear");
		if (spearObj) {
			Invoke("DestorySpear(spearObj)", 2);
		}

		spearObj = Instantiate(spear) as GameObject;

		weapons = GameObject.FindWithTag ("weapons");
		Vector3 tempSpear = spearObj.transform.position;
		tempSpear.x = GetGroundPosition ();
		spearObj.transform.position = tempSpear;
		spearObj.transform.parent = weapons.transform;
	}

	private float GetGroundPosition() {
		float vecPosX = 0f;
		groundLists = GameObject.FindGameObjectsWithTag ("ground");
		foreach(GameObject obj in groundLists) {
			if (obj.GetComponent<GroundController>().onRobot == false) {
				vecPosX = obj.transform.position.x;
			}
		}
		return vecPosX;
	}

	private void DestorySpear(GameObject spearObj) {
		Destroy (spearObj);
	}

	public void DestroyAllSpear() {
		if (!weapons) {
			return;
		}

		Transform[] children = weapons.GetComponentsInChildren<Transform>();
		foreach(Transform t in children) {
			GameObject ga = t.gameObject;
			Destroy (ga);
		}
	}
}
