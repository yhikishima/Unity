using UnityEngine;
using System.Collections;

public class DestroyArea : MonoBehaviour {

	void OnTriggeerExit2D (Collider2D c) {
		Destroy (c.gameObject);
	}
}
