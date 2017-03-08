using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeController : MonoBehaviour {
	public int[,] map;
	public Vector2 startPosition;
	public Vector2 endPosition;
	public GameObject wallPrefab;
	public GameObject exitPrefab;
	public GameObject startPrefab;
	public GeneticAlgorithm geneticAlgorithm;

	public GameObject PrefabByTile(int tile) {
		if (tile == 1) return wallPrefab;
		if (tile == 5) return startPrefab;
		if (tile == 8) return exitPrefab;
		return null;
	}

	public double TestRoute(List<int> directions) {
		Vector2 position = startPosition;

		for (int directionIndex = 0; directionIndex < directions.Count; directionIndex++) {
			int nextDirection = directions [directionIndex];

			switch (directions [directionIndex]) {
			case 0: // North
				if (position.y - 1 < 0 || map [(int)(position.y - 1), (int)position.x] == 1) {
					break;
				} else {
					position.y -= 1;
				}
				break;
			case 1: // South
				if (position.y + 1 >= map.GetLength (0) || map [(int)(position.y + 1), (int)position.x] == 1) {
					break;
				} else {
					position.y += 1;
				}
				break;
			case 2: // East
				if (position.x + 1 >= map.GetLength (1) || map [(int)position.y, (int)(position.x + 1)] == 1) {
					break;
				} else {
					position.x += 1;
				}
				break;
			case 3: // West
				if (position.x - 1 < 0 || map [(int)position.y, (int)(position.x - 1)] == 1) {
					break;
				} else {
					position.x -= 1;
				}
				break;
			}
		}

		Vector2 deltaPosition = new Vector2(
			Math.Abs(position.x - endPosition.x),
			Math.Abs(position.y - endPosition.y));
		return 1/(double)(deltaPosition.x + deltaPosition.y + 1);
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
		startPosition = new Vector2 (14f, 7f);
		endPosition = new Vector2 (0f, 2f);

		geneticAlgorithm = new GeneticAlgorithm ();
		geneticAlgorithm.Run ();
	}

	public void RenderFittestChromosomePath() {
	}
	
	// Update is called once per frame
	void Update () {
		if (geneticAlgorithm.busy) geneticAlgorithm.Epoch ();
		RenderFittestChromosomePath ();
	}
}
