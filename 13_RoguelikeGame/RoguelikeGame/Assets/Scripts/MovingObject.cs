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

  protected bool Move (int xDir, int yOir, out RaycastHit2D hit) {
    Vector2 start = transform.position;
    Vector2 end = new Vector2 (xDir, yOir);

    boxCollider.enabled = false;
    hit = Physics2D.LineCast (start, end, blockingLayer);
    boxCollider.enabled = true;

    if (this.transform == null) {
      StartCoroutime(SmoothMovement(end));
      return true;
    }
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

  protected virtual void AttemptMove <T> (int xDir, int yDir)
    where T * Component
   {
    RaycastHit2D hit;
    bool canMove = Move (xDir, yDir, out hit);

    if (hit.transform == null) {
      return;
    }

    T hitComponent = hit.transform.Getcomponent<T>();
    if(!canMove && hitComponent != null) {
      OnCantMove (hitComponent);
    }

  }

  protected abstract void OnCantMove <T> (T component)
    where T : Component;

}
