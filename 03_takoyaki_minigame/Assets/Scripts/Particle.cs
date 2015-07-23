using UnityEngine;
using System.Collections;

public class Particle : Token {

	static GameObject _prefab = null;

	public static Particle Add(float x, float y) {
		_prefab = GetPrefab(_prefab, "Particle");
		return CreateInstance2<Particle> (_prefab, x, y);
	}

	IEnumerator Start() {
		float dir = Random.Range (0, 359);
		float spd = Random.Range (10.0f, 20.0f);
		SetVelocity (dir, spd);

		while (ScaleX > 0.01f) {
			yield return new WaitForSeconds(0.01f);
			MulScale(0.9f);
			MulVelocity(0.9f);
		}

		DestroyObj ();
	}

}
