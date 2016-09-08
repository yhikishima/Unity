using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointManager : MonoBehaviour {
	public static int GamePoint = 0;
	public GameObject point;

	private Text pointText;

	// Use this for initialization
	void Start () {
		pointText = point.GetComponent<Text> ();	
	}
	
	// Update is called once per frame
	void Update () {
		pointText.text = GamePoint.ToString();
	}
}
