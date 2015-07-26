﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 5;
	public GameObject bullet;

	IEnumerator Start() {
		while(true){
			Instantiate (bullet, transform.position, transform.rotation);
			yield return new WaitForSeconds(0.05f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");
		
		Vector2 direction = new Vector2(x, y).normalized;
		
		rigidbody2D.velocity = direction * speed;	
	}
}
