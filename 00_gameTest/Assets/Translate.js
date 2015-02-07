#pragma strict

function Start () {

}

public var x : float;
public var y : float;
public var z : float;

function Update () {
	 transform.Translate(0, 0, 1 * Time.deltaTime);
}