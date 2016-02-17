using UnityEngine;
using System.Collections;


public class GameManager : MonoBehaviour {
	public GameObject Block;

	// Use this for initialization
	void Start () {
		InstantBlock ();
	}

	void Update () {
		if (!BlockManager.BlockDropFlg) {
			Debug.Log ("落ちるよ");
			InstantBlock();
			BlockManager.BlockDropFlg = true;
		}
	}

	private void InstantBlock() {
		Instantiate(Block);
	}
}
