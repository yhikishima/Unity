using UnityEngine;
using System.Collections;

public class GroundController : MonoBehaviour {
	public bool onRobot = false;
	public int planeNum;

	private float waitTime = 0;
	private float time;


	// Use this for initialization
	void Start () {
		time = 0f;
	}
	
	// Update is called once per frame
	void Update () {

	}
		
	private void OnCollisionEnter(Collision collision) {
		if (!onRobot) {
			StartCoroutine(UpdateGrounds());
		}
	}

	private IEnumerator UpdateGrounds() {

		yield return new WaitForSeconds(waitTime);

		GameObject clone = Object.Instantiate (gameObject) as GameObject;
		float objX = transform.position.x;

		// planeのclone作成
		clone.transform.Translate(objX, 0, 0);
		var groundController = clone.GetComponent<GroundController>();
		groundController.planeNum = planeNum + 1;
		clone.transform.parent = transform.parent;


		// 不要になったgroundを削除
		GameObject[] groundList = GameObject.FindGameObjectsWithTag("ground");
		foreach(GameObject obs in groundList) {
			if (obs.GetComponent<GroundController>().onRobot == true) {
				Destroy(obs);
			}
		}

		onRobot = true;
	}
}
