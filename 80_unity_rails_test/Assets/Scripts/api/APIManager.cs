using UnityEngine;
using System;
using System.Collections;
using MiniJSON;
using System.Collections.Generic;

public class APIManager : MonoBehaviour {

	private string listUrl = "http://0.0.0.0:3000/lists";

	// Use this for initialization
	IEnumerator Start () {
		// var www = new WWW(listUrl);
		// yield return www;

		// Debug.Log("読み込み完了");

		// Debug.Log(www);

		// var jsonText = www.text;


		// Debug.Log(jsonText);

		// 文字列を json に合わせて構成された辞書に変換
		// var json = Json.Deserialize (jsonText) as List<Dictionary<string, string>>;

		// Debug.Log(json);

		// Debug.Log((Sting)jsonDict["message"]);


		WWW www = new WWW(listUrl);
        // webサーバから何らかの返答があるまで停止
        yield return www;
        // もし、何らかのエラーがあったら
        if(!string.IsNullOrEmpty(www.error)){
            // エラー内容を表示
            Debug.LogError(string.Format("Fail Whale!\n{0}", www.error));
            yield break; // コルーチンを終了
        }


		// var textAsset = Resources.Load ("sample") as TextAsset;
		// var jsonText = textAsset.text;

		string jsonText = www.text;

// JSONデータは最初は配列から始まるので、Deserialize（デコード）した直後にリストへキャスト
        var familyList = Json.Deserialize(jsonText) as IList;
        // リストの内容はオブジェクトなので、辞書型の変数に一つ一つ代入しながら、処理
        foreach(IDictionary person in familyList){
            // nameは文字列なので、文字列型へキャストしてから変数へ格納
            string name = (string)person["name"];
            Debug.Log("name:"+name);
            // ageは整数型なので、long型にキャストしてから変数へ格納

        }
	}

	// Update is called once per frame
	void Update () {

	}
}
