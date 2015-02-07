#pragma strict

function Start () {

}

function Update () {

}

function OnCollisionEnter() {
	Destroy( this.gameObject, 3.0 );
}