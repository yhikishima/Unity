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

  public int columns = 8;
  public int rous = 8;
  public Count wallCount = new Count (5, 9);
  public Count foodCount = new Count (5, 9);
  public GameObject exit;
  public GameObject[] floorTiles;
  public GameObject[] wallTiles;
  public GameObject[] foodTiles;
  public GameObject[] enemyTiles;
  public GameObject[] outerWallTiles;

  private Transform boardHolder;
  private List <Vector> gridPositions = new List<Vector3>();

  void InitialiseList() {
    gridPositions.clear();

    for (int x = 1; x < columns -1; x++) {
        for (int y = 1; y < rows -1; y++) {
          gridPositions.Add(new Vector3(x,y,0f));
        }
    }
  }

  void BoardSetup() {
    boardHolder = new GameObject ("Board").transform;

    for (int x = -1; x < columns + 1; x++) {
      for (int y = -1; y < rows; y++) {
        GameObject toInstantiate = floorTiles[Random.Range (0, floorTiles.Length)];
      }
    }
  }

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
