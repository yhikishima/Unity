using UnityEngine;
using System.Collections;

public class WaeponController : MonoBehaviour {
	public GameObject spear;

	private GameObject spearObj;
	private GameObject[] groundLists;

	private float speed = 1.0f;
	private float waitingTime = 3.0f;

	// Use this for initialization
	void Start () {
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

//		GameObject Nyago = GameObject.FindWithTag ("Player");
		spearObj = Instantiate(spear) as GameObject;

		GameObject weapons = GameObject.FindWithTag ("waepons");
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
}
