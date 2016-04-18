using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {
	public Transform target;
	private Vector3 targetOffset; // ターゲットとの相対座標

	// Use this for initialization
	void Start () {
		FollowRobot ();
	}

	// Update is called once per frame
	void Update () {
		// 自分の座標にtargetの座標を代入する + デフォルトの相対座標
		GetComponent<Transform>().position = target.position + targetOffset;
	}

	private void FollowRobot () {
		//自分自身とtargetとの相対距離を求める
		targetOffset = GetComponent<Transform>().position - target.position;
	}
}
