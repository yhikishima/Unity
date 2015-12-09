using UnityEngine;
using System.Collections;

public class TextureScript : MonoBehaviour {
	Texture texture1;
	Renderer renderer;
	Color color1;

	// Use this for initialization
	void Start () {
		texture1 = (Texture)Resources.Load("MudRockNormals");
		renderer = GetComponent<Renderer> ();
		color1 = renderer.material.color;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (1f, 1f, 0.1f);
		if (Input.GetKeyDown (KeyCode.Space)) {
			renderer.material.mainTexture = texture1;
			renderer.material.color = Color.white;
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			renderer.material.mainTexture = null;
			renderer.material.color = color1;
		}
	
	}
}
