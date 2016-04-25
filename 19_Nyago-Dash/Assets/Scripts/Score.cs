using UnityEngine;
using System.Collections;

/*
* イメージ
* ranking = [
*   {no, name, time},
*   {no, name, time}
* ];
*/

public class Score : MonoBehaviour {
  public int score = 0;
  private string RANKING_PREF_KEY = "ranking";
  private float[] ranking = new float[10];

  void Awake() {
    score = PlayerPrefs.GetInt(RANKING_PREF_KEY, 0);
    foreach(float val in ranking) {
      Debug.Log(val);
    }
  }
  void Start() {
    int score = dealScore;
    Debug.Log(score);
  }

  void Update() {
    
  }

  public float[] dealScore {
    get {
      return PlayerPrefs.GetFloat(RANKING_PREF_KEY);
    }
    set {
      PlayerPrefs.SetFloat(RANKING_PREF_KEY, ranking);
    }
  }
  
  public void getRanking() {
    // float[] _ranking = PlayerPrefs.GetString(RANKING_PREF_KEY);
    // if (_ranking.length > 0) {
      
    // }
  }
  
  public void setRanking(float newScore) {
    // float tmp = 0f;
    // var ranking = ranking;
    // if (ranking) {

    // } else {
    //   ranking[0] = newScore;
    // }
    
    // string[] rankingArray = ranking
    // PlayerPrefs.SetString(RANKING_PREF_KEY, rankingArray);
  }
  
  public void deleteScore() {
    PlayerPrefs.DeleteKey(RANKING_PREF_KEY);
  }
}