using UnityEngine;
using System.Collections;


public class GameManager : MonoBehaviour {
	public GameObject Block;
//	BlockManager blockManager;
//	GameObject CameraObj;

	// Use this for initialization
	void Start () {
		InstantBlock ();
		Debug.Log (BlockManager.BlockDropFlg);
//		CameraObj = GameObject.Find("Main Camera");
//		blockManager = CameraObj.GetComponent<BlockManager>();

//		InvokeRepeating("InstantBlock", 2, 2);
	}

	void Update () {
		Debug.Log ("ああああ");
//		Debug.Log (BlockManager.BlockDropFlg);

		if (!BlockManager.BlockDropFlg) {
			Debug.Log ("落ちるよ");
			Instantiate(Block);
			BlockManager.BlockDropFlg = true;
		}
	}

	private void InstantBlock() {
		Instantiate(Block);
	}
}
