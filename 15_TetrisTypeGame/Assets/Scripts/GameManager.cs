using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject Block;

	// Use this for initialization
	void Start () {

		// 2秒ごとにゲージが減る
		InvokeRepeating("InstantBlock", 2, 2);
	}
	

	private void InstantBlock() {
		Instantiate(Block);
	}
}
