#pragma strict

var movingSpeed : float = 5.0;
private var controller : CharacterController;
private var velocity : Vector3;

function Start () {
	controller = GetComponent(CharacterController);

}

function Update () {
	transform.position.y = 0;
	velocity = Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
	velocity *= movingSpeed;
	
	controller.Move(velocity * Time.deltaTime);
}