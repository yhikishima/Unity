using UnityEngine;
using System.Collections;

public class ParticleScript : MonoBehaviour {
	GameObject[] cubes = new GameObject[4];
	GameObject[] gos = new GameObject[4];
	float fog = 0;

	// Use this for initialization
	void Start () {
		RenderSettings.fogMode = FogMode.Exponential;
		RenderSettings.fog = true;
		RenderSettings.fogColor = Color.gray;
		RenderSettings.fogDensity = 0f;

		for (int i =0; i < 4; i++) {
			cubes[i] = GameObject.Find ("Cube" + i);
			gos[i] = GameObject.Find ("GameObject" + i);
		}
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody rigidbody = GetComponent<Rigidbody> ();

		if (RenderSettings.fogDensity < fog) {
			RenderSettings.fogDensity += 0.0001f;
		}

		foreach(GameObject obj in cubes) {
			obj.transform.Rotate(new Vector3(1f, 1f, 1f));
		}
		Vector3 v = transform.position;
		v.y += 2;
		v.z -= 7;
		Camera.main.transform.position = v;

		if (Input.GetKey(KeyCode.LeftArrow)) {
			rigidbody.AddForce(new Vector3(-1f, 0, 0)); // To left roll
		}
		
		if (Input.GetKey(KeyCode.RightArrow)) {
			rigidbody.AddForce (new Vector3(1f, 0, 0)); // TO right roll
		}
		
		if (Input.GetKey(KeyCode.UpArrow)) {
			rigidbody.AddForce (new Vector3(0, 0, 1f)); // TO top roll
		}
		
		if (Input.GetKey(KeyCode.DownArrow)) {
			rigidbody.AddForce (new Vector3(0, 0, -1f)); // TO bottom roll
		}

	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.name.StartsWith("Cube")) {
			for(int i = 0; i < 4; i++) {
				if (cubes[i] == collider.gameObject) {
					ParticleSystem ps = gos[i].GetComponent<ParticleSystem>();
					ps.Play ();
					cubes[i].SetActive(false);
				}
			}
		}
	}

	void OnTriggerExit(Collider collider) {
		if (collider.name == "Cylinder") {
			Behaviour b = (Behaviour)collider.gameObject.GetComponent("Halo");
			b.enabled = true;
		}
	}
}
