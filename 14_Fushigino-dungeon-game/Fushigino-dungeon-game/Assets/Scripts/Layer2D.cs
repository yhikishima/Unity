using UnityEngine;
using System.Collections;

public class Layer2D : MonoBehaviour {

	const int MAP_MAX_X = 34; // ステージの幅
	const int MAP_MAX_Z = 34; // ステージの高さ
	public GameObject block; // ブロックオブジェクト

	int[,] mapNo = new int[MAP_MAX_Z, MAP_MAX_X];             // 34×34のマップ番号
	GameObject[,] obj = new GameObject[MAP_MAX_Z, MAP_MAX_X]; // 34×34のオブジェクト

	// Use this for initialization
	void Start () {
		// 初めはブロックを全て埋める
		for (int y = 0; y < MAP_MAX_Z; y++)
		{
			Debug.Log ("sssss");
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	void AllWall() {

	}
}
