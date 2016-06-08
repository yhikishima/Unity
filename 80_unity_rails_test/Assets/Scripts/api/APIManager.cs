using UnityEngine;
using System.Collections;
using MiniJSON;
using System.Collections.Generic;

public class APIManager : MonoBehaviour {

	private string listUrl = "http://localhost:3000/lists";

	// Use this for initialization
	IEnumerator Start () {
		WWW www = new WWW(listUrl);
		yield return www;

		Debug.Log("読み込み完了");

		Debug.Log(www);

		var jsonText = www.text;

		// 文字列を json に合わせて構成された辞書に変換
		var json = Json.Deserialize (jsonText) as Dictionary<string, string>;

		Debug.Log(json);

		// Debug.Log((Sting)jsonDict["message"]);
	}

	// Update is called once per frame
	void Update () {

	}
}
