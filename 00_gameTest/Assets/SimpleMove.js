#pragma strict

public var run : float = 20.0;
private var velocity: Vector3;

function Start () {

}

function Update () {
 	var controller : CharacterController =
 		GetComponent( CharacterController );
	{
		velocity = Vector3( Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical") );
		velocity *= run;
		controller.SimpleMove( velocity );
	}

}