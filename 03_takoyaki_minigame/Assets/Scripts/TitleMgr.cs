using UnityEngine;
using System.Collections;

public class TitleMgr : MonoBehaviour {
	void OnGUI() {
		Util.SetFontSize (32);
		Util.SetFontAlignment (TextAnchor.UpperCenter);

		float w = 128;
		float h = 32;
		float px = Screen.width / 2 - w / 2;
		float py = Screen.height / 2 - h / 2;
		Util.GUILabel(px, py, w, h, "MINI GAME");

		py += 60;
		if (GUI.Button (new Rect (px, py, w, h), "START")) {
			Application.LoadLevel("Main");	
		}
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
