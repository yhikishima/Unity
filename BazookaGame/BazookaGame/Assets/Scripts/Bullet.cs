using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	void OnCollisionEnter(Collision collision) {
		if (collision.collider.name == "Plane") {
			Destroy(this.gameObject, 2.5f);
		} else if (collision.collider.tag == "Teddy") {
			Destroy(this.gameObject);
		}
	}
}
