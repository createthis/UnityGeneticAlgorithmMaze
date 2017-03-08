using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeController : MonoBehaviour {
	public int[,] map;
	public Vector3 startPosition;
	public Vector3 endPosition;
	public GameObject wallPrefab;
	public GameObject exitPrefab;
	public GameObject startPrefab;

	public GameObject PrefabByTile(int tile) {
		if (tile == 1) return wallPrefab;
		if (tile == 5) return startPrefab;
		if (tile == 8) return exitPrefab;
		return null;
	}

	public void Populate() {
		Debug.Log ("length(0)=" + map.GetLength(0));
		Debug.Log ("length(1)=" + map.GetLength(1));

		for (int y = 0; y < map.GetLength(0); y++) {
			for (int x = 0; x < map.GetLength(1); x++) {
				GameObject prefab = PrefabByTile (map [y, x]);
				if (prefab != null) {
					GameObject wall = Instantiate (prefab);
					wall.transform.position = new Vector3 (x, 0, -y);
				}
			}
		}
	}

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
		Populate ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
