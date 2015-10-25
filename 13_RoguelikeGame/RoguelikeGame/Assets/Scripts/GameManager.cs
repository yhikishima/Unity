using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

  public BoardManager boardScript;

  private int level = 3;

  void Awake () {
    boardScript = GetComponent<BoardManager>();
    initGame();
  }

	// Use this for initialization
	void InitGame () {
    boardScript.SetupScene(level);
	}

	// Update is called once per frame
	void Update () {

	}
}
