#pragma strict

public var value:float;

function Start () {

}

function Update () {

}

function OnGUI() {
	value = GUI.HorizontalSlider( Rect( 10, 50, 10, 40), value, 0,  500 );
	GUI.Label( Rect(120, 10, 100, 40), value.ToString() );
}