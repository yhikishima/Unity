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
    Debug.Log(rankingArray.Count);

    sortRanking();

    setRanking();

    setScoreBoard();
  }

  void Update() {

  }

  void FixedUpdate() {
		if (robot.isDie && !checkRanking) {
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

      if (checkRanking) {
        return;
      }

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
      if (goalTimes.Length > 1) {
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
          return;
        } else if (second == goalTimes[0]) {
          if (point > goalTimes[1]) {
            return;
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

      // for (int j = 0; j < ranks.Length; j++) {
      //   ranksFloatList[j] = float.Parse(ranks[j]);
      // }

      foreach(string s in ranks) {
        Debug.Log("string");
        Debug.Log(s);
        ranksString += s;
      }
      Debug.Log("ranksString");
      Debug.Log(ranksString);
      ranksFloat = float.Parse(ranksString);

      sortList.Add(ranksFloat);
      // compareTime.Add(float.Parse(ranks[0]));
    }

    sortList.Sort();
    Debug.Log("===================sortList=================");
    Debug.Log(sortList[0]);
    Debug.Log(sortList[1]);
    Debug.Log(sortList[2]);

    rankingArray.Clear();

    foreach(float s in sortList) {
      string sortListStr =  s.ToString();

      // floatによって、数値が6けたじゃなくなっているので、調整
      for(int k = 0; k < 6; k++) {
        if (sortListStr.Length == 6) {
          k = 6;
        } else {
          sortListStr = "0" + sortListStr;
        }
      }

      Debug.Log("length");
      Debug.Log(sortListStr);
      Debug.Log(sortListStr.Length);

      string minStr = sortListStr.Substring(0, 2);
      string secondStr = sortListStr.Substring(2, 2);
      string pointStr = sortListStr.Substring(4, 2);
      rankingArray.Add(minStr + ":" + secondStr + ":" + pointStr);
    }
  }

  void setScoreBoard() {
    Debug.Log(rankingArray.Count);

    for(int i = 0; i < rankingArray.Count; i++) {
      var targetObj = rankObj[i];
      var targetName = rankObj[i].name;
      GameObject time = targetObj.transform.FindChild("time").gameObject;

      string[] no = rankObj[i].name.Split("Rank"[3]);
      int number = int.Parse(no[1]);

      time.GetComponent<Text>().text = (rankingArray[i-1]).ToString();
    }
  }

  public List<string> getRanking() {
    string _ranking = PlayerPrefs.GetString(RANKING_PREF_KEY);
    Debug.Log("rank");
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