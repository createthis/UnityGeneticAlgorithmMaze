using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeController : MonoBehaviour {
  public int[,] map;
  public Vector3 startPosition;
  public Vector3 endPosition;

	// Use this for initialization
	void Start () {
		map = new int[,] {
      {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
      {1,0,1,0,0,0,0,0,1,1,1,0,0,0,1},
      {8,0,0,0,0,0,0,0,1,1,1,0,0,0,1},
      {1,0,0,0,1,1,1,0,0,1,0,0,0,0,1},
      {1,0,0,0,1,1,1,0,0,0,0,0,1,0,1},
      {1,1,0,0,1,1,1,0,0,0,0,0,1,0,1},
      {1,0,0,0,0,1,0,0,0,0,1,1,1,0,1},
      {1,0,1,1,0,0,0,1,0,0,0,0,0,0,5},
      {1,0,1,1,0,0,0,1,0,0,0,0,0,0,1},
      {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
      };
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
