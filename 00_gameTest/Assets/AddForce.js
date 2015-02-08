#pragma strict

private var target : GameObject;
public var speed : float =  1.0; 

function Start () {
	target = GameObject.FindGameObjectWithTag("player");
}

function Update () {

}

function FixedUpdate() {
	var direction = target.transform.position - transform.position;
 	rigidbody.AddForce( direction.normalized * speed );
 }