using UnityEngine;
using System.Collections;

public class Animation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AnimationClip clip = new AnimationClip ();
		clip.legacy = true;
		AnimationCurve curve = AnimationCurve.Linear (0f, 3f, 3f, 3f);
		Keyframe key = new Keyframe (1.5f,7f);
		curve.AddKey (key);
		clip.SetCurve ("", typeof(Transform), "localPosition.z", curve);
		clip.wrapMode = WrapMode.Loop;
		Animation anim = GetComponent<Animation>();

		anim.Start ();


		anim.AddClip(clip, "clip1");
		anim.Play("clip1");
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (1f, 1f, 1f);
	}
}
