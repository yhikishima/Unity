using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class myscript : MonoBehaviour {
	public Text text;
	public Text text2;

	// Use this for initialization
	void Start () {
		SetText ();
		SetText2 ();

	}

	private void SetText () {
		int num = 1234567;
		bool flg = true;
		for (int i = 2; i<= (num/2); i++) {
			if (num % i == 0) {
				flg = false;
				break;
			}
		}
		string s = "string s is equal sosuu";
		
		if (flg){
			s +="desu!";
			
		} else {
			s +="jyanai!";
		}
		text.text = s;		
	}

	private void SetText2 () {
		//  practice Array
		string[] array = {"Hello", "Welcom", "Bye"};
		string str = array [0] + "," + array [1] + "," + array [2];

		//  practice Array and Foreach
		int[] data = {98, 72, 64, 15};
		int total = 0;
		foreach(int n in data) {
			total += n;
		}
		int ave = total / 5;
		text2.text = "total:" + total + ", " + "average:" + ave;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
