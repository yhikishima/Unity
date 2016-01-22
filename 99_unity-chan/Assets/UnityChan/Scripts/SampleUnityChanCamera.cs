using UnityEngine;
using System.Collections;

public class SampleUnityChanCamera : MonoBehaviour {
	public GameObject target = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = target.transform.position;
		position.y += 1f;
		position.z -= 3f;
		transform.position = position;
	}
}
