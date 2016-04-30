using UnityEngine;
using System.Collections;
using System.Text;
using System;
using UnityEngine.UI;
using System.Collections.Generic;

public class Score : MonoBehaviour {
  public int score = 0;
  private string RANKING_PREF_KEY = "ranking";
  private List<string> rankingArray = new List<string>();
  private GameObject scoreObj;
  private GameObject[] rankObj;

	private Robot robot;
  private TimerController timer;

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

    GameObject TimerObj = GameObject.FindWithTag ("timer");
    timer = TimerObj.GetComponent<TimerController>();

		GameObject Nyago = GameObject.FindWithTag ("Player");
		robot = Nyago.GetComponent<Robot>();
    
    
    // default設定
    // foreach(GameObject rank in rankObj) {
    //   rankingArray.Add("00:00");      
    // }

    // rankingArray.Sort();
    // setRanking();
    rankingArray.Clear();
    rankingArray = getRanking();
    
    setScoreBoard();
  }

  void Update() {
    
  }
  
  void FixedUpdate() {
		if (robot.isDie) {
      Debug.Log("die");
      float[] currentTimes = timer.GetCurrentTime();
      compareRanking(currentTimes);
    }
  }
  
  private void compareRanking(float[] times) {
    float minutes;
    float second;
    float point;
    rankingArray = getRanking();

    foreach(string rank in rankingArray) {
      string[] ranks = rank.Split(":"[0]);
      // 分、秒、ミリ秒が設定されている
      if (ranks.Length > 1) {
        second = float.Parse(ranks[0]);
        point = float.Parse(ranks[1]);
      // 秒、ミリ秒が設定されている
      } else {
        minutes = float.Parse(ranks[0]);
        second = float.Parse(ranks[1]);
        point = float.Parse(ranks[2]);
      }

     // 分、秒、ミリ秒が設定されている
      if (rankingArray.Count > 1) {
        
      // 秒、ミリ秒が設定されている
      } else {
        if (minutes > rankingArray[0]) {
                    
        }
      }
    }
  }
  
  void setScoreBoard() {
    for(int i = 0; i < rankingArray.Count; i++) {
      GameObject time = rankObj[i].transform.FindChild("time").gameObject;
      
      string[] no = rankObj[i].name.Split("Rank"[3]);
      int number = int.Parse(no[1]);

      time.GetComponent<Text>().text = (rankingArray[i]).ToString();
      // time.GetComponent<GUIText>().text = "aaa";
    }
  }
  
  public List<string> getRanking() {
    string _ranking = PlayerPrefs.GetString(RANKING_PREF_KEY);
    List<string> rankStrings = new List<string>();
    
    if (string.IsNullOrEmpty(_ranking)) {
      foreach(GameObject rank in rankObj) {
        rankStrings.Add("00:00");      
      }

      return rankStrings;
    } else {
      string[] rankSplit = _ranking.Split(',');
      foreach(string r in rankSplit) {
        if (string.IsNullOrEmpty(r)) {
          rankStrings.Add("00:00");
        } else {
          rankStrings.Add(r);
        }
      }

      return rankStrings;
    }
  }
  
  public void setRanking() {
    var builder = new StringBuilder();
    foreach(string rank in rankingArray) {
      builder.Append(rank + ",");
    }
    PlayerPrefs.SetString(RANKING_PREF_KEY, builder.ToString());
  }
  
  public void deleteScore() {
    PlayerPrefs.DeleteKey(RANKING_PREF_KEY);
  }
}