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
	private bool enemiesMoving;

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
		if (playersTurn || enemiesMoving)
			return;

		StartCoroutine (MoveEnemies ());
	}

	public void AddEnemyToList(Enemy script) {
		enemies.Add (script);
	}

	IEnumerator MoveEnemies() {
		enemiesMoving = true;
		yield return new WaitForSeconds (turnDelay);
		if (enemies.Count == 0) {
			yield return new WaitForSeconds(turnDelay);
		}

		for (int i = 0; i < enemies.Count; i++) {
			enemies[i].MoveEnemy();
			yield return new WaitForSeconds(enemies[i].moveTime);
		}

		playersTurn = true;
		enemiesMoving = false;
	}
}
