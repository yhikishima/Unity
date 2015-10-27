using UnityEngine;
using System.Collections;

public abstract class MovingObject : MonoBehaviour {

  public float moveTime = 0.1f;
  public LayerMask blockingLayer;

  private BoxCollider2D boxCollider;
  private RigidBody2D rb2D;
  private float inverseMoveTime;


  protected virtual void Start () {
    boxCollider = GetComponent<BoxCollider2D>();
    rb2D = GetComponent<Rigidbody2D>();
    inverseMoveTime = 1f / moveTime;
  }

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
