using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;

/*
* イメージ
* ranking = [
*   {no, time},
*   {no, time}
* ];
*/

public class Score : MonoBehaviour {
  public int score = 0;
  private string RANKING_PREF_KEY = "ranking";
  private float[] rankingArray = new float[10];

  void Awake() {
    // ranking = [
    //   {"no": 1, "name": "aiu", time: 10}
    // ];
    // score = PlayerPrefs.GetInt(RANKING_PREF_KEY, );
    // foreach(float val in ranking) {
    //   Debug.Log(val);
    // }
  }
  void Start() {
    string[] score = dealScore;
    Debug.Log(score);
    
    rankingArray[0] = 10.5f;
    rankingArray[1] = 8.5f;
    rankingArray[2] = 12.5f;
    
    Debug.Log(rankingArray[0]);
    Debug.Log(rankingArray[1]);
    Debug.Log(rankingArray[2]);

  }

  void Update() {
    
  }

  public string[] dealScore {
    get {
      string _ranking = PlayerPrefs.GetString(RANKING_PREF_KEY);
      string[] rankSplit = _ranking.Split(',');
      return rankSplit;
    }
    set {
      var builder = new StringBuilder();
      foreach(float rank in rankingArray) {
        string rankTemp = rank.ToString();
        builder.Append(rankTemp);
      }
      //  = string.Join(",", rankingArray.ToString());
      // PlayerPrefs.SetString(RANKING_PREF_KEY, rankingString);
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