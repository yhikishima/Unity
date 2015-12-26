using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using System.Collections;

public class RigidBodyScript : MonoBehaviour {
	int counter = 0;
	GameObject obj = null;


	// Use this for initialization
	void Start () {
		GameObject[] objs  = GameObject.FindGameObjectsWithTag("Player");
		foreach (GameObject obj in objs) {
			Renderer renderer = obj.GetComponent<Renderer>();
			renderer.material.SetFloat("_Mode", 3f);
			renderer.material.SetInt("_SrcBlend", (int)BlendMode.SrcAlpha);
			renderer.material.SetInt("_DstBlend", (int)BlendMode.OneMinusSrcAlpha);
			renderer.material.SetInt("_ZWrite", 0);
			renderer.material.DisableKeyword("_ALPHATEST_ON");
			renderer.material.EnableKeyword("_ALPHATEST_ON");
			renderer.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
			renderer.material.renderQueue = 3000;

		}

	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject cube = GameObject.Find("Cube2");
		Debug.Log(cube);

		Rigidbody rigidbody = GetComponent<Rigidbody> ();

//		if (obj != null) {
//			if (counter++ > 100) {
//				obj.SetActive(true);
//				obj = null;
//			}
//		}
//
		try {
			cube.transform.Rotate (1f, -1f, -1f);
		} catch (System.NullReferenceException e) {
			Debug.Log (e);
		}



		if (Input.GetKey(KeyCode.LeftArrow)) {
			rigidbody.AddForce(new Vector3(-1f, 0, 1f)); // To left roll
		}

		if (Input.GetKey(KeyCode.RightArrow)) {
			rigidbody.AddForce (new Vector3(1f, 0, -1f)); // TO right roll
		}

		if (Input.GetKey(KeyCode.UpArrow)) {
			rigidbody.AddForce (new Vector3(1f, 0, 1f)); // TO top roll
		}

		if (Input.GetKey(KeyCode.DownArrow)) {
			rigidbody.AddForce (new Vector3(-1f, 0, -1f)); // TO bottom roll
		}
	}

	//  collider test, Atack to Cube so Cube color is yello 
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name != "Plane" ) {
			collision.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
		}

		if (collision.gameObject.tag == "Player" ) {
//			if (obj != null) {
//				obj.SetActive(true);
//			}
//			collision.gameObject.SetActive(false);
//			obj = collision.gameObject;
//			counter = 0;

			Renderer renderer = collision.gameObject.GetComponent<Renderer>();
			Color color = renderer.material.color;
			color.a = 0.25f;
			renderer.material.color = color;
		}

//		if (collision.gameObject.name == "Cube2") {
//			collision.gameObject.GetComponent<Renderer>().material.color = new Color(1f, 0, 0, 0.25f);
//
//		}
	}

	void OnCollisionExit(Collision collision) {
		if (collision.gameObject.tag == "Player") {
			Renderer renderer = collision.gameObject.GetComponent<Renderer>();
			Color color = renderer.material.color;
			color.a = 1.0f;
			renderer.material.color = color;
		}
	}
}
