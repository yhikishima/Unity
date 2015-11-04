using UnityEngine;
using System.Collections;

public class Player : MovingObject {
  public int wallDamage = 1;
  public int pointsPerFood = 10;
  public int pointsPerSoda = 20;
  public float restartLevelDelay = 1f;

  private Animator animator;
  private int food;

  protected override void Start () {
    animator = GetComponent<Animator>();

    food = GameManager.instance.playerFoodPoint;

    base.Start();
  }

  private void OnDisabled() {
    GameManager.instance.playerFoodPoints = food;
  }

	// Update is called once per frame
	void Update () {
    if (!GameManager.instance.playersTurn) {
      return;
    }

    int horizontal = 0;
    int vertical = 0;

    if (horizontal != 0) {
      vertivcal = 0;
    }

    if (horizontal !=0 || vertical !=0) {
      AttemptMove<Wall> (horizontal, vertical);
    }

	}

  protected override void AttemptMove<T> (int xDir, int yDir) {
    food--;

    base.AttemptMove <T> (xDir, yDir);
    RaycastHit2D hit;
    CheckIfGameOver();

    GameManager.instance.playersTurn = false;
  }


  private void CheckIfGameOver() {
    if (food <= 0) {
      GameManager.instance.Gameover();
    }
  }
}
