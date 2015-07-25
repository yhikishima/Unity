using UnityEngine;
using System.Collections;

public class Enemy : Token {

	public static int Count = 0;

	// Use this for initialization
	void Start () {
		Count++;
		SetSize(SpriteWidth / 2, SpriteHeight / 2);

		float dir = Random.Range(0, 359);
		float spd = 5;
		SetVelocity (dir, spd);
	}

	void Update() {
		Vector2 min = GetWorldMin ();
		Vector2 max = GetWorldMax ();

		if (X < min.x || max.x < X) {
			VX *= -1;
			ClampScreen();
		}
		if (Y < min.y || max.y < Y) {
			VY *= -1;
			ClampScreen();
		}
	}

	public void OnMouseDown() {
		Count--;

		for (int i = 0; i < 32; i++) {
			Particle.Add (X, Y);	
		}

		DestroyObj ();
	}
}
