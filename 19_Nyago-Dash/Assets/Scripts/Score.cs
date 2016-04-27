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
  private float[] rankingArray = new float[5];
  private GameObject scoreObj;
  private GameObject[] rankObj;

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
		scoreObj = GameObject.FindWithTag ("score");
    rankObj = GameObject.FindGameObjectsWithTag("rank");
    
    rankingArray[0] = 10.5f;
    rankingArray[1] = 8.5f;
    rankingArray[2] = 12.5f;
    
    Debug.Log(rankingArray[0]);
    Debug.Log(rankingArray[1]);
    Debug.Log(rankingArray[2]);
    
    setRanking();
    var tmp = getRanking();
    Debug.Log(tmp[0]);
    Debug.Log(tmp[1]);
    
    setScoreBoard();
  }

  void Update() {
    
  
  }
  
  private void setScoreBoard() {
    for(int i = 0; i < rankingArray.Length; i++) {
      GameObject time = rankObj[i].transform.FindChild("time").gameObject;
      
      // time.GetComponent<GUIText>().text = "aaa";
    }
  }
  
  public string[] getRanking() {
    string _ranking = PlayerPrefs.GetString(RANKING_PREF_KEY);
    string[] rankSplit = _ranking.Split(',');
    return rankSplit;
  }
  
  public void setRanking() {
    var builder = new StringBuilder();
    foreach(float rank in rankingArray) {
      string rankTemp = rank.ToString();
      builder.Append(rankTemp + ",");
    }
    //  = string.Join(",", rankingArray.ToString());
    PlayerPrefs.SetString(RANKING_PREF_KEY, builder.ToString());
  }
  
  public void deleteScore() {
    PlayerPrefs.DeleteKey(RANKING_PREF_KEY);
  }
}