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

	private GameObject selfGameObject;
	private GameObject otherGameObject;

	void Start () {
		Dictionary<string, Color> colroData = new Dictionary<string, Color>();
		colroData.Add ("red", Color.red);
		colroData.Add ("blue", Color.blue);
		colroData.Add ("yellow", Color.yellow);
		colroData.Add ("green", Color.green);

		string randomColor = colorArray[Random.Range(0, colorArray.Length)];

//		Color randomColor = new Color( Random.value, Random.value, Random.value, 1.0f );
		float randomVal = Random.value;
		randomVal = Mathf.Ceil (randomVal * 100);

		gameObject.GetComponent<Renderer>().material.color = colroData[randomColor];

		gameObject.name = randomColor + "Block" + randomVal;
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

	string GetContactObject() {
		if (otherGameObject.CompareTag ("StopWall")) {
			return "StopWall";
		} else if (otherGameObject.CompareTag ("Block")) {
			return "Block";
		} else {
			return "";
		}
	}

	bool SearchSameColor() {
		if (selfGameObject.GetComponent<BlockManager> ().colorTag == otherGameObject.GetComponent<BlockManager> ().colorTag) {
			Debug.Log ("同じ色じゃん");
			return true;
		} else {
			return false;
		}
	}

	bool SearchParent(GameObject selfObj) {
		if (selfObj.transform.parent) {
			Debug.Log ("親いるーじゃん");
			return true;
		} else {
			return false;
		}
	}

	void CreateParents() {
		// 同じ色かどうか
		bool isSameColor = SearchSameColor();

		// 親がいるかどうか
		bool isParent = SearchParent(selfGameObject);
		bool isOtherParent = SearchParent(otherGameObject);
	
		if (!isSameColor) {
			return;
		}

		// 同じ色で親がいなければ親を作る
		if ((isParent == false) && (isOtherParent == false)) {
			GameObject obj = new GameObject();
			obj.name = "parent";
			selfGameObject.transform.parent = obj.transform;

		} else if((isParent == false) && isOtherParent) {
			selfGameObject.transform.parent = otherGameObject.transform.parent;
		// 両方親がいれば、３個の親を作る
		} else if (isParent && isOtherParent) {

			// すでに親がparent3だったら消す
			if (selfGameObject.transform.parent.name == "parent3") {
				DestroyGameobject(selfGameObject.transform.parent.gameObject);
			}

			selfGameObject.transform.parent.name = "parent3";
		}
	}

	private void DestroyGameobject(GameObject targetGamepbject) {
		Destroy (targetGamepbject);
		PointManager.GamePoint += 100;
	}
		
	/*
	 * 
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
	 * 
	 * 

	 *     →
		*/

	void OnCollisionEnter(Collision other) {
		selfGameObject = gameObject;
		otherGameObject = other.gameObject;

		CapsuleCollider Capcol = selfGameObject.GetComponent<Collider>() as CapsuleCollider;

		string contactObject = GetContactObject();

		// 接地位置
		Vector3 contact = other.contacts [0].point;
		bool isOtherContactPos = (contact.x != otherGameObject.transform.position.x) ? true : false;

		// 接地位置が下でなかったら、抜ける
		if ((contactObject == "Block") && isOtherContactPos) {
			CreateParents ();

			return;
		}

		// 接地面が下の場合は止める
		if ((contactObject == "Block") && !isOtherContactPos) {
			BlockDropFlg = false;
			stopFlg = true;

			CreateParents ();

			return;
		}

		//
//		// 止めるかどうか
		if (contactObject == "StopWall") {
			Capcol.attachedRigidbody.useGravity = true;
			Capcol.attachedRigidbody.constraints = RigidbodyConstraints.None;
			BlockDropFlg = false;
			stopFlg = true;

			return;
		}
	}

	// 離れた
	void OnCollisionExit(Collision other) {
		selfGameObject = gameObject;
		otherGameObject = other.gameObject;

		bool isSameColor = SearchSameColor();

		if (!isSameColor) {
			return;
		}

		var selfParent = selfGameObject.transform.parent;
		var otherParent = otherGameObject.transform.parent;

		if (!selfParent && !otherParent) {
			return;
		}

		if (otherParent) {
			otherGameObject.transform.parent = null;
			GameObject parent = otherParent.root.gameObject;
			Destroy (parent);
		}

		Debug.Log ("aaa");

		//		Debug.Log (other.contacts);
//		Vector3 contact = other.contacts[0].point;
//
//		if (contact.x == gameObject.transform.position.x) {
//			BlockDropFlg = true;
//			stopFlg = false;
//		}
	}
}
