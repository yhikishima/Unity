using UnityEngine;
using System;
using System.Collections;
using System.Text;
using UnityEngine.UI;
using System.Collections.Generic;

public class Score : MonoBehaviour {
  public int score = 0;
  private string RANKING_PREF_KEY = "ranking";
  private List<string> rankingArray = new List<string>();
  private GameObject scoreObj;
  private GameObject[] rankObj;

  private bool checkRanking = false;

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
    // deleteScore();
    // rankingArray.Clear();
    rankingArray = getRanking();
    sortRanking();

    setRanking();

    setScoreBoard();
  }

  void Update() {

  }

  void FixedUpdate() {
		// if (robot.isDie || robot.isGoal && !checkRanking) {
    //   Debug.Log("die");
    // }

    if (robot.isGoal && !checkRanking) {
      float[] currentTimes = timer.GetCurrentTime();
      compareRanking(currentTimes);
    }
  }


  /*
  goalTimes = [currentMin, currentSecond, currentPoint];
  */
  private void compareRanking(float[] goalTimes) {
    float minutes = 0;
    float second = 0;
    float point = 0;
    rankingArray = getRanking();
    Debug.Log(rankingArray);

    for (int i = 0; i < rankingArray.Count; i++) {

      string[] ranks = rankingArray[i].Split(":"[0]);

      minutes = float.Parse(ranks[0]);
      second = float.Parse(ranks[1]);
      point = float.Parse(ranks[2]);

      // 分、秒、ミリ秒が設定されている
      if (goalTimes.Length > 1) {
        // どちらが大きいか比較
        if (minutes > goalTimes[0]) {
          continue;

        } else if (minutes == goalTimes[0]) {
          if (second > goalTimes[1]) {
            continue;
          } else if (second == goalTimes[1]) {
            if (point > goalTimes[2]) {
              continue;
            }
          }
        }

        // ランキングに設定
        string minutesText = goalTimes[0].ToString();
        if (minutesText.Length == 1) minutesText = "0" + minutesText;
        string secondText = goalTimes[1].ToString();
        if (secondText.Length == 1) secondText = "0" + secondText;
        string pointText = goalTimes[2].ToString();
        if (pointText.Length == 1) pointText = "0" + pointText;

        string newRank = minutesText + ":" + secondText + ":" + pointText;
        rankingArray.Remove(rankingArray[i]);
        rankingArray.Add(newRank);

      // 秒、ミリ秒が設定されている
      } else {
        // どちらが大きいか比較
        if (second > goalTimes[0]) {
          continue;
        } else if (second == goalTimes[0]) {
          if (point > goalTimes[1]) {
            continue;
          }
        }

        // ランキングに設定
        string secondText = goalTimes[0].ToString();
        if (secondText.Length == 1) secondText = "0" + secondText;
        string pointText = goalTimes[1].ToString();
        if (pointText.Length == 1) pointText = "0" + pointText;

        string newRank = secondText + ":" + pointText;
        rankingArray.Remove(rankingArray[i]);
        rankingArray.Add(newRank);
      }

      setRanking();
      setScoreBoard();
      checkRanking = true;
    }
  }

  private void sortRanking() {
     Hashtable tmpHash = new Hashtable();
     List<float> sortList = new List<float>();

    for (int i = 0; i < rankingArray.Count; i++) {
      string[] ranks = rankingArray[i].Split(":"[0]);
      float[] ranksFloatList = new float[ranks.Length];
      float ranksFloat;
      string ranksString = "";

      foreach(string s in ranks) {
        ranksString += s;
      }
      ranksFloat = float.Parse(ranksString);

      sortList.Add(ranksFloat);
    }

    sortList.Sort();
    // rankingArray = sortList;

    rankingArray.Clear();

    foreach(float s in sortList) {
      string sortListStr =  s.ToString();
      Debug.Log(sortListStr);

      // floatによって、数値が6けたじゃなくなっているので、調整
      for(int k = 0; k < 6; k++) {
        if (sortListStr.Length == 6) {
          k = 6;
        } else {
          sortListStr = "0" + sortListStr;
        }
      }

      string minStr = sortListStr.Substring(0, 2);
      string secondStr = sortListStr.Substring(2, 2);
      string pointStr = sortListStr.Substring(4, 2);
      string addStr = minStr + ":" + secondStr + ":" + pointStr;

      if (addStr != "00:00:00") {
        rankingArray.Add(addStr);
      }
    }

    for (var i=0; i < 5; i++) {
      if (rankingArray.Count == 5){
        i = 5;
      } else {
        rankingArray.Add("00:00:00");
      }
    }
  }

  void setScoreBoard() {
    for(int i = 0; i < 5; i++) {
      var targetObj = rankObj[i];
      var targetName = rankObj[i].name;
      GameObject time = targetObj.transform.FindChild("time").gameObject;

      string[] no = rankObj[i].name.Split("Rank"[3]);
      int number = int.Parse(no[1]);

      time.GetComponent<Text>().text = (rankingArray[number-1]).ToString();
    }
  }

  public List<string> getRanking() {
    string _ranking = PlayerPrefs.GetString(RANKING_PREF_KEY);
    Debug.Log("==============rank=================");
    Debug.Log(_ranking);
    List<string> rankStrings = new List<string>();

    if (string.IsNullOrEmpty(_ranking)) {
      foreach(GameObject rank in rankObj) {
        rankStrings.Add("00:00:00");
      }

      return rankStrings;
    } else {
      string[] rankSplit = _ranking.Split(',');
      foreach(string r in rankSplit) {
        if (string.IsNullOrEmpty(r)) {
          rankStrings.Add("00:00:00");
        } else {
          rankStrings.Add(r);
        }
      }

      if (rankStrings.Count < 5) {
        for(var i=0; i < 5; i++) {
          rankStrings.Add("00:00:00");

          if (rankStrings.Count == 5) {
            i = 5;
          }
        }
      }

      return rankStrings;
    }
  }

  public void setRanking() {
    var builder = new StringBuilder();
    for (int i = 0; i < rankingArray.Count; i++) {
      if (i == rankingArray.Count-1) {
        builder.Append(rankingArray[i]);
      } else {
        builder.Append(rankingArray[i] + ",");
      }

    }
    PlayerPrefs.SetString(RANKING_PREF_KEY, builder.ToString());
  }

  public void deleteScore() {
    PlayerPrefs.DeleteKey(RANKING_PREF_KEY);
  }
}