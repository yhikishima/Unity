using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject Block;

	// Use this for initialization
	void Start () {
		Instantiate(Block);
	}
	
	// Update is called once per frame
	void Update () {
		Instantiate(Block);
	}
}
