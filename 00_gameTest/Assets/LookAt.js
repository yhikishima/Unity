#pragma strict

function Start () {

}

function Update () {
	 var target : GameObject = GameObject.Find( "target" );
	 transform.LookAt(  target.transform.position );
}
