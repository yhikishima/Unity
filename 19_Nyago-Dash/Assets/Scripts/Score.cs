using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
  int score = 0;
  void Awake() {
    score = PlayerPrefs.GetInt("Score");
  }
  void Update() {
    
  }

  public void SetScore() {
    PlayerPrefs.SetInt("Score", Score);
  }
}