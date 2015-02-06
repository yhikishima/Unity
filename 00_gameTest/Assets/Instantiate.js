#pragma strict

public var Prefab : GameObject;

function OnGUI() {
	if ( GUI.Button( Rect(8, 8, 100, 50), "Instantiate" ) ) {
		var x : float = Random.Range( -3.0f, 3.0f );
		var y : float = Random.Range( -3.0f, 3.0f );
		var z : float = Random.Range( -3.0f, 3.0f );
		
		Instantiate( Prefab, Vector3(x, y, z),
			Quaternion.identity );
	}
}

