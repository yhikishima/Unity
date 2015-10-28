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

  protected bool Movee (int xDir, int yOir, out RaycastHit2D hit) {

  }

  protected IEnumerator SmoothMovement (Vector3 end) {
    float sqrRemaining = (transform.position - end).sqrMagnitude;

    while (sqrRemaining > float.Epsilon) {
      Vector3 newPosition = Vector3.MoveTowards(rb2D.position, end, inverseMoveTime * Time.deltaTime);
      rb2D.MovePosition(newPosition);
      sqrRemainingDistanse = (transform.position - end).sqlMagnitude;
      yield return null;
    }
  }

  protected abstract void OnCantMove <T> (T component)
    where T : Component;

}
