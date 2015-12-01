using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class myscript : MonoBehaviour {
	public Text text;
	public Text text2;
	public Text text3;

	struct Hello {
		public string name;
		public string maker;
		public int price;
		public Hello(string n, string m, int p) {
			name = n;
			maker = m;
			price = p;
		}
	}

	int counter = 0;
	float plus = 0.1f;
	float zvalue = 0f;

	float dx = 0.01f;
	float dy = -0.01f;

	
	// Use this for initialization
	void Start () {
		SetText ();
		SetText2 ();
		string msg = "Hello!"; 
		SetText3 (msg);

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

	private void SetText3 (string m) {
		Hello h = new Hello (m, "wagashi", 125);
		string s = h.name + "," + h.maker + h.price;
		text3.text = s;
	}


	// Update is called once per frame
	void Update () {
		ZoomIn ();
		Transform ();
		ChangeWH ();


	}

	private void ZoomIn () {
		zvalue += 0.1f;
		Vector3 p = new Vector3 (0, 0, zvalue);
		transform.position = p;
		if (zvalue > 10) {
			zvalue = 0;
		}		
	}

	private void Transform () {
		var v = new Vector3 (0.1f, 0.1f, 0.1f);
		transform.Rotate (v);
	}

	private void ChangeWH () {
		Vector3 s = transform.localScale;
		if (s.x > 3 || s.x < 0.1) {
			dx *= -1;
		}
		if (s.y > 3 || s.y < 0.1) {
			dy *= -1;
		}
		s.x += dx;
		s.y += dy;
		transform.localScale = s;
	}
}
