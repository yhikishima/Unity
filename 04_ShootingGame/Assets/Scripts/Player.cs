using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	Spaceship spaceship;
	

	IEnumerator Start() {
		spaceship = GetComponent<Spaceship> ();

		while(true){
			spaceship.Shot (transform);
			yield return new WaitForSeconds (spaceship.shotDelay);
//			Instantiate (bullet, transform.position, transform.rotation);
//			yield return new WaitForSeconds(0.05f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");
		
		Vector2 direction = new Vector2(x, y).normalized;
		
//		rigidbody2D.velocity = direction * speed;	

		spaceship.Move (direction);
	}

	void OntriggerEnter2D (Collider2D c){
		Destroy (c.gameObject);
		spaceship.Explosion ();
		Destroy (gameObject);
	}
		
}
