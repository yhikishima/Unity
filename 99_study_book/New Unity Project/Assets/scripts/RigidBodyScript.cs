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
			Keyframe[] keysY = new Keyframe[2];
			keysY[0] = new Keyframe(0f,move.y);
			keysY[1] = new Keyframe(1f,move.y);

			AnimationCurve curveY = new AnimationCurve(keysY);
			clip.SetCurve("", typeof(Transform), "localPosition.y", curveY);
			Keyframe[] keysZ = new Keyframe[2];
			keysZ[0] = new Keyframe(0f,move.z);
			keysZ[1] = new Keyframe(1f,move.z);
			AnimationCurve curveZ = new AnimationCurve(keysZ);
			clip.SetCurve("", typeof(Transform), "localPosition.z", curveZ);
			Animation animation = obj.GetComponent<Animation>();
//			animation.AddClip(clip, "clip1");
//			animation.Play("clip1");

		}
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody rigidbody = GetComponent<Rigidbody>();
		Renderer renderer = GetComponent<Renderer>();
	
		MoveCube ();

		rigidbody.AddForce (0f, 0f, -1f);

		if (flg) {
			if (Input.GetKey(KeyCode.Space)) {
				power += 0.01f;
				if (power > 1f) {
					power = 0.25f;
				}
				renderer.material.color = new Color(1f,power,0f);
			}
		}

		if (Input.GetKeyUp(KeyCode.Space)) {
			rigidbody.AddForce(new Vector3(0f,0f,power*3000f));
			power = 0f;
			renderer.material.color = Color.red;
			flg = false;
		}

//		if (obj != null) {
//			if (counter++ > 100) {
//				obj.SetActive(true);
//				obj = null;
//			}
//		}
//
//		try {
//			cube.transform.Rotate (1f, -1f, -1f);
//		} catch (System.NullReferenceException e) {
//			Debug.Log (e);
//		}
//
//
//
//		if (Input.GetKey(KeyCode.LeftArrow)) {
//			rigidbody.AddForce(new Vector3(-1f, 0, 1f)); // To left roll
//		}
//
//		if (Input.GetKey(KeyCode.RightArrow)) {
//			rigidbody.AddForce (new Vector3(1f, 0, -1f)); // TO right roll
//		}
//
//		if (Input.GetKey(KeyCode.UpArrow)) {
//			rigidbody.AddForce (new Vector3(1f, 0, 1f)); // TO top roll
//		}
//
//		if (Input.GetKey(KeyCode.DownArrow)) {
//			rigidbody.AddForce (new Vector3(-1f, 0, -1f)); // TO bottom roll
//		}
	}

	void MoveCube() {
		foreach(GameObject obj in ob_cubes) {
			obj.transform.Rotate(new Vector3(0f,1f,0f));
		}
	}

	//  collider test, Atack to Cube so Cube color is yello 
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "ob_cube" ) {
//			collision.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
			Behaviour b = (Behaviour)collision.gameObject.GetComponent("Hello");
			b.enabled = true;
		}

//		if (collision.gameObject.tag == "Player" ) {
//			if (obj != null) {
//				obj.SetActive(true);
//			}
//			collision.gameObject.SetActive(false);
//			obj = collision.gameObject;
//			counter = 0;

//			Renderer renderer = collision.gameObject.GetComponent<Renderer>();
//			Color color = renderer.material.color;
//			color.a = 0.25f;
//			renderer.material.color = color;
//		}
//
//		if (collision.gameObject.name == "Cube2") {
//			collision.gameObject.GetComponent<Renderer>().material.color = new Color(1f, 0, 0, 0.25f);
//
//		}
	}

	void OnCollisionExit(Collision collision) {
		Rigidbody rigidbody = GetComponent<Rigidbody> ();
		if (collision.gameObject.tag == "ob_cube") {
			Behaviour b = (Behaviour)collision.gameObject.GetComponent("Halo");
			b.enabled = false;
			Vector3 v = rigidbody.velocity;
			if (v.magnitude < 15) {
				v *= 2.0f;

				if (v.magnitude < 5) {
					v *= 2.0f;
				}
				rigidbody.velocity = v;
			}
		}

		if (collision.gameObject.tag == "ob_wall") {
			Vector3 v = rigidbody.velocity;
			if (v.magnitude < 15) {
				v *= 2.0f;
				if (v.magnitude < 5) {
					v *= 2.0f;
				}
				rigidbody.velocity = v;
			}
		}

	}

	void OnTriggerEnter(Collider collider) {
		Rigidbody rigidbody = GetComponent<Rigidbody> ();
		if (collider.gameObject.tag == "goal") {
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;
			int n = 1;
			foreach(GameObject obj in goals) {
				if (obj == collider.gameObject) {
					score.text = "point:" + (n * 100);
					ParticleSystem ps = collider.gameObject.GetComponent<ParticleSystem>();
					ps.Play ();
				}
				n ++;
			}
		}
	}
}
