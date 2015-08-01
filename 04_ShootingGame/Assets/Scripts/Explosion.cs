using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	// Use this for initialization
	void OnAnimationFinish () {
		Destroy (gameObject);
	
	}
	
}
