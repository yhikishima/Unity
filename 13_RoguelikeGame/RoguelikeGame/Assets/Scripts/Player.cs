﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MovingObject {
  public int wallDamage = 1;
  public int pointsPerFood = 10;
  public int pointsPerSoda = 20;
  public float restartLevelDelay = 1f;
	public Text foodText;
	public AudioSource moveSound01;
	public AudioSource moveSound02;
	public AudioSource eatSound1;
	public AudioSource eatSound2;
	public AudioSource drinkSound1;
	public AudioSource drinkSound2;
	public AudioSource gameOverSound;

  private Animator animator;
  private int food;

  protected override void Start () {
    animator = GetComponent<Animator>();

    food = GameManager.instance.playerFoodPoints;

		foodText.text = "Food:" + food; 

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

		horizontal = (int) (Input.GetAxisRaw ("Horizontal"));
		vertical = (int) (Input.GetAxisRaw ("Vertical"));


	    if (horizontal != 0) {
	      vertical = 0;
	    }

	    if (horizontal !=0 || vertical !=0) {
	      AttemptMove<Wall> (horizontal, vertical);
	    }

	}

  protected override void AttemptMove<T> (int xDir, int yDir) {


    	food--;
		foodText.text = "Food:" + food; 	

    	base.AttemptMove <T> (xDir, yDir);
		RaycastHit2D hit;

		if (Move (xDir, yDir, out hit)) 
		{
			SoundManager.instance.RandomizeSfx (moveSound01, moveSound02);
	
		}

    	CheckIfGameOver();

    	GameManager.instance.playersTurn = false;
  }

  private void OnTriggerEnter2D (Collider2D other) {
    if (other.tag == "Exit") {
      Invoke ("Restart", restartLevelDelay);
      enabled = false;

    } else if (other.tag == "Food") {
      food += pointsPerFood;
			foodText.text = "+" + pointsPerFood + "Food:" + food;
			SoundManager.instance.RandomizeSfx(eatSound1, eatSound2);
      other.gameObject.SetActive(false);

    } else if (other.tag == "Soda") {
      food += pointsPerSoda;
			foodText.text = "+" + pointsPerFood + "Food:" + food;
			SoundManager.instance.RandomizeSfx(drinkSound1, drinkSound2);
			other.gameObject.SetActive(false);
    }
  }

  protected override void OnCantMove <T> (T component) {
    Wall hitWall = component as Wall;

    hitWall.DamageWall (wallDamage);
    animator.SetTrigger ("playerChop");
  }

  private void Restart() {
    Application.LoadLevel(Application.loadedLevel);
  }

  public void LoseFood (int loss) {
    animator.SetTrigger ("playerHit");
    food -= loss;
		foodText.text = "-" + loss + "Food: " + food;
    CheckIfGameOver();
  }


  private void CheckIfGameOver() {
    if (food <= 0) {
			SoundManager.instance.PlaySingle(gameOverSound);
			SoundManager.instance.musicSource.Stop ();
      GameManager.instance.GameOver();
    }
  }
}
