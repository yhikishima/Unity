using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	private static SoundManager instance;
	public AudioClip explosionAudio;
	
	public static SoundManager Instance {
		get {
			if (instance == null) {
				instance = (SoundManager)FindObjectOfType(typeof(SoundManager));
				if (instance == null) {
					Debug.LogError("SoundManager Instance Error");
				}
			}
			return instance;
		}
	}
	
	public void PlayExplosionAudio() {
		audio.PlayOneShot(explosionAudio);
	}
}
