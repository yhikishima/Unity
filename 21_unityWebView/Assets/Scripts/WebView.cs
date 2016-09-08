using UnityEngine;
using System.Collections;

public class WebView : MonoBehaviour {

	private string url = "https://localhost:3001/tweets/index/";

	// Use this for initialization
	void Start () {
		var _webView = GetComponent<UniWebView>();

		_webView.url = url;
		_webView.Load();
		_webView.Show();
	}

	// Update is called once per frame
	void Update () {

	}
}
