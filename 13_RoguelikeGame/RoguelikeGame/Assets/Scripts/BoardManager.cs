using UnityEngine;
using System;
using System.Collections;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {

  [Serializable]
  public class Count {
    public int minimum;
    public int maximum;

    public Count (int min, int max) {
      minimum = min;
      maximum = max;
    }
  }

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
