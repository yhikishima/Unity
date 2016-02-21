using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BlockManager : MonoBehaviour {
	float spd = 0.6f;
	float blockH;
	public static bool BlockDropFlg = true;
	public string colorTag;

	private bool stopFlg = false;
	private string[] colorArray = new string[] {"red", "blue", "yellow", "green"};
	private int blockConcat = 1;

	void Start () {
		blockH = Screen.width;

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

	void OnCollisionEnter(Collision col) {
		var colGameObj = col.gameObject;

		if (colGameObj.CompareTag("Block") && colorTag == colGameObj.GetComponent<BlockManager>().colorTag) {
			Debug.Log (col.gameObject.transform.childCount);

			// 2個の時
			if (transform.parent && !colGameObj.transform.parent) {
				Debug.Log ("いたよ。。親が");

				colGameObj.transform.parent = transform.parent;

			// 2個のとき
			} else if (colGameObj.transform.parent && !transform.parent) {
				Debug.Log ("いたよ。。こっちの親が");
				transform.parent = colGameObj.transform.parent;

			// 3個以上のとき
			} else if (colGameObj.transform.parent && transform.parent) {

				Debug.Log ("いたよ。。両方の親が");

				if (transform.parent.name == "parent3") {
					Destroy (transform.parent.gameObject);
				} else {
					transform.parent.name = "parent3";				
				}

			// １個の時
			} else {
				GameObject obj = new GameObject();
				obj.name = "parent";

				Debug.Log ("親いないね");

				if (colGameObj.transform.childCount > 1) {
					Debug.Log ("aaaaaaa");
					//				Destroy (colGameObj);	
					//				if (gameObj.transform.childCount == 2) {
					//					Destroy (gameObj.transform.parent);
					//				}
					transform.parent = obj.transform;

				} else {
					colGameObj.transform.parent = obj.transform;
				}
			
			
			}

		}
			
		if (col.gameObject.CompareTag("StopWall") || col.gameObject.CompareTag("Block")) {
			BlockDropFlg = false;
			stopFlg = true;
		}
	}
}
