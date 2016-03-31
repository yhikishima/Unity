using UnityEngine;
using System.Collections;

public class GameObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// 3.1 オブジェクトの親子関係
		GameObject div = new GameObject();
		div.transform.name = "First Object";
		GameObject div2 = new GameObject ();
		div2.transform.name = "Second Object";
		div.transform.parent = div2.transform;
	
	}
}
