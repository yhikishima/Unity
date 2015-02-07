#pragma strict

function Start () {

}

function Update () {
	 transform.Rotate( 0,1,0 );
	 transform.localScale.x =   Mathf.Sin( Time.time * 10.0 ) + 1.5;
}