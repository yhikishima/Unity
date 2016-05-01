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

    foreach(GameObject rank in rankObj) {
      rankingArray.Add("00:00");      
    }
    
    setRanking();
    
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


  /*
  goalTimes = [currentMin, currentSecond, currentPoint];
  */
  private void compareRanking(float[] goalTimes) {
    float minutes = 0f;
    float second = 0f;
    float point = 0f;
    rankingArray = getRanking();
    
    for (int i = 0; i < rankingArray.Count; i++) {
      string[] ranks = rankingArray[i].Split(":"[0]);

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
        // どちらが大きいか比較
        if (minutes > goalTimes[0]) {
          return;

        } else if (minutes == goalTimes[0]) {
          if (second > goalTimes[1]) {
            return;
          } else if (second == goalTimes[1]) {
            if (point > goalTimes[2]) {
              return;
            }
          }
        }
        
        // ランキングに設定
        string newRank = goalTimes[0].ToString() + ":" + goalTimes[1].ToString() + ":" + goalTimes[2].ToString();
        rankingArray.Remove(rankingArray[i]);
        rankingArray.Add(newRank);

        Console.WriteLine("aaa");
        Debug.Log(newRank);

      // 秒、ミリ秒が設定されている
      } else {
        // どちらが大きいか比較
        if (second > goalTimes[0]) {
          return;
        } else if (second == goalTimes[0]) {
          if (point > goalTimes[1]) {
            return;
          }
        }
        
        // ランキングに設定
        string newRank = goalTimes[1].ToString() + ":" + goalTimes[2].ToString();
        rankingArray.Remove(rankingArray[i]);
        rankingArray.Add(newRank);

        Console.WriteLine("bbb");
        Debug.Log(newRank);
      }
    }
  }
  
  void setScoreBoard() {
    Debug.Log(rankingArray.Count);
    
    for(int i = 0; i < rankingArray.Count; i++) {
      GameObject time = rankObj[i].transform.FindChild("time").gameObject;
      
      string[] no = rankObj[i].name.Split("Rank"[3]);
      int number = int.Parse(no[1]);

      time.GetComponent<Text>().text = (rankingArray[i]).ToString();
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