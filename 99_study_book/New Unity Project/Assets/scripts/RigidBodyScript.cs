using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using System.Collections;

public class RigidBodyScript : MonoBehaviour {
	GameObject[] ob_cubes;
	GameObject[] goals;
	float power = 0f;
	bool flg = true;
	public Text score;

	// Use this for initialization
	void Start () {
		ob_cubes = GameObject.FindGameObjectsWithTag ("ob_cube");
		goals = GameObject.FindGameObjectsWithTag ("goal");
		int n = 0;
		foreach (GameObject obj in goals) {
			Renderer renderer = obj.GetComponent<Renderer>();
			renderer.material.SetFloat("_Mode", 3f);
			renderer.material.SetInt("_SrcBlend", (int)BlendMode.SrcAlpha);
			renderer.material.SetInt("_DstBlend", (int)BlendMode.OneMinusSrcAlpha);
			renderer.material.SetInt("_ZWrite", 0);
			renderer.material.DisableKeyword("_ALPHATEST_ON");
			renderer.material.EnableKeyword("_ALPHATEST_ON");
			renderer.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
			renderer.material.renderQueue = 3000;
			renderer.material.color = new Color(0f, 0.15f * n, 1f - 0.15f * n++, 0.5f);
		}

		foreach (GameObject obj in ob_cubes) {
			Vector3 move = obj.transform.position;
			AnimationClip clip = new AnimationClip();
			clip.legacy = true;
			Keyframe[] keysX = new Keyframe[2];
			keysX[0] = new Keyframe(0f, move.x - 5);
			keysX[1] = new Keyframe(1f, move.x + 3);
			AnimationCurve curveX = new AnimationCurve(keysX);
			clip.SetCurve("", typeof(Transform), "localPosition.x", curveX);
			clip.wrapMode = WrapMode.PingPong;


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
