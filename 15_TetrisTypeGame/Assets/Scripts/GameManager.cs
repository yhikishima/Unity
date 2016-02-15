using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject Block;
	BlockManager blockManager;

	// Use this for initialization
	void Start () {
		InstantBlock ();
//		InvokeRepeating("InstantBlock", 2, 2);
	}

	void Update () {
		if (!blockManager.BlockDropFlg) {
			Debug.Log ("落ちるよ");
			InstantBlock ();
		}
	}

	private void InstantBlock() {
		Instantiate(Block);
	}
}
