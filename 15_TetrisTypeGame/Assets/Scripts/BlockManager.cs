using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BlockManager : MonoBehaviour {
	float spd = 0.6f;
	public static bool BlockDropFlg = true;
	public string colorTag;

	private bool stopFlg = false;
	private string[] colorArray = new string[] {"red", "blue", "yellow", "green"};

	void Start () {
		Dictionary<string, Color> colroData = new Dictionary<string, Color>();
		colroData.Add ("red", Color.red);
		colroData.Add ("blue", Color.blue);
		colroData.Add ("yellow", Color.yellow);
		colroData.Add ("green", Color.green);

		string randomColor = colorArray[Random.Range(0, colorArray.Length)];

//		Color randomColor = new Color( Random.value, Random.value, Random.value, 1.0f );
		gameObject.GetComponent<Renderer>().material.color = colroData[randomColor];
		colorTag = randomColor;

		InvokeRepeating("dropBlock", 1, 1);
	}

	void dropBlock () {
		if (!stopFlg) {
			Vector3 transformPos = transform.position;
			transformPos.y -= 0.6f;
			transform.position = transformPos;
		}
	}

	void Update () {
		Vector3 transformPos = transform.position;

		if (!stopFlg) {
			if (Input.GetKeyDown("right")) {
				transformPos.x += spd;
			}
			if (Input.GetKeyDown("left")) {
				transformPos.x -= spd;
			}

			if (Input.GetKeyDown("down")) {
				transformPos.y -= spd;
			}

			transform.position = transformPos;
		}
	}

	string GetContactObject(GameObject otherGameObj) {
		if (otherGameObj.CompareTag ("StopWall")) {
			return "StopWall";
		} else if (otherGameObj.CompareTag ("Block")) {
			return "Block";
		} else {
			return "";
		}
	}


	/*
	 * 設計を考えてみる！
	 * 
	 * ①１つの時
	 * →　何もなし
	 * ②２つの時
	 * ・やりたきこと
	 * 　・parentオブジェクトを作成して、２つを囲い込む
	 * 　・動いていた側
	 *     →親オブジェクトを作成し、作成した親オブジェクトの子供になる。
	 * 　・止まっていた側
	 *     →相手（動いていた側）に親オブジェクトがあれば、その親オブジェクトの子供になる。
	 * ③３つの時
	 * 　・動いていた側
	 *     →相手（止まっていた側）に親オブジェクトがあれば、その親オブジェクトの子供になる。
	 *     →その場合は親の名前を「parent3」とする
	 * 　・止まっていた側
	 *     →自分に親オブジェクトがあれば、何もしない
	 * ④４つの時
	 * 　・動いていた側
	 *     →相手の親オブジェクトが「parent3」ならば「parent3」と自分の親オブジェクトも含めdestroyする
	*/


	void OnCollisionEnter(Collision other) {
		GameObject otherGameObj = other.gameObject;
		CapsuleCollider Capcol = gameObject.GetComponent<Collider>() as CapsuleCollider;


		Vector3 contact = other.contacts [0].point;
		string contactObject = GetContactObject(otherGameObj);

		// 着地
		if (contact.x == gameObject.transform.position.x && (contactObject == "StopWall" || contactObject == "Block")) {
			if (Capcol != null) {
//				Capcol.radius = 0.5f;
			}

//			Capcol.attachedRigidbody.useGravity = true;
//			Capcol.attachedRigidbody.constraints = RigidbodyConstraints.None;
			BlockDropFlg = false;
			stopFlg = true;
		}

		if (contact.x != gameObject.transform.position.x && contactObject == "StopWall") {
			return;
		}

		// 結合
		if (otherGameObj.CompareTag("Block") && colorTag == otherGameObj.GetComponent<BlockManager>().colorTag) {

			// 2個の時
			if (transform.parent && !otherGameObj.transform.parent) {
				Debug.Log ("いたよ。。親が");	

				otherGameObj.transform.parent = transform.parent;

			// 2個のとき
			} else if (otherGameObj.transform.parent && !transform.parent) {
				Debug.Log ("いたよ。。こっちの親が");
				transform.parent = otherGameObj.transform.parent;

			// 3個以上のとき
			} else if (otherGameObj.transform.parent && transform.parent) {

				Debug.Log ("いたよ。。両方の親が");

				if (transform.parent.name == "parent3") {
					Destroy (transform.parent.gameObject);
					PointManager.GamePoint += 100;

				} else {
					transform.parent.name = "parent3";				
				}

			// １個の時
			} else {
				GameObject obj = new GameObject();
				obj.name = "parent";
				Debug.Log ("親いないね");

				if (otherGameObj.transform.childCount > 1) {
					transform.parent = obj.transform;

				} else {
					otherGameObj.transform.parent = obj.transform;
				}
			}
		}
	}

	void OnTriggerExit(Collider other) {
		Debug.Log ("離れた");
		Debug.Log (other);

		//		Debug.Log (other.contacts);
//		Vector3 contact = other.contacts[0].point;
//
//		if (contact.x == gameObject.transform.position.x) {
//			BlockDropFlg = true;
//			stopFlg = false;
//		}
	}
}
