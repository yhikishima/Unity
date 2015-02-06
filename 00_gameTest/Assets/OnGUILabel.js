#pragma strict

public var style : GUIStyle;

function Start () {
	style = GUIStyle();
	style.fontSize = 30;
}

function Update () {

}

// create label
function OnGUI() {
	var rect: Rect =  Rect( 20, 20, 100, 40 );
	GUI.Label( rect, "Unity is wonderful", style );
}