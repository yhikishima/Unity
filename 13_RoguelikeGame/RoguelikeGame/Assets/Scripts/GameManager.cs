using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
  public float turnDelay = .1f;

  public static GameManager instance = null;
  public BoardManager boardScript;
  public int playerFoodPoints = 100;
  [HideInInspector] public bool playersTurn = true;

  private int level = 3;
	private List<Enemy> enemies;
	private bool ememiesMoving;

	void Awake () {

		if (instance == null)
		  instance = this;
		else if (instance != this)
		  Destroy(gameObject);
		boardScript = GetComponent<BoardManager>();
		InitGame();
	}

	// Use this for initialization
	void InitGame () {
	    boardScript.SetupScene(level);
		enemies.Clear ();
	}

	public void GameOver() {
		enabled = false;
	}

	// Update is called once per frame
	void Update () {

	}

	IEnumerator MoveEnemies() {
		enemiesMoving = true;
	}
}
