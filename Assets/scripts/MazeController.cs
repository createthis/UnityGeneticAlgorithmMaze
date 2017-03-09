using System;
using System.Linq;
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
	public GameObject pathPrefab;
	public GeneticAlgorithm geneticAlgorithm;
	public List<int> fittestDirections;
	public List<GameObject> pathTiles;
	public GameObject text;

	public GameObject PrefabByTile(int tile) {
		if (tile == 1) return wallPrefab;
		if (tile == 5) return startPrefab;
		if (tile == 8) return exitPrefab;
		return null;
	}

	public Vector2 Move(Vector2 position, int direction) {
		switch (direction) {
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
		return position;
	}

	public double TestRoute(List<int> directions) {
		Vector2 position = startPosition;

		for (int directionIndex = 0; directionIndex < directions.Count; directionIndex++) {
			int nextDirection = directions [directionIndex];
			position = Move (position, nextDirection);
		}

		Vector2 deltaPosition = new Vector2(
			Math.Abs(position.x - endPosition.x),
			Math.Abs(position.y - endPosition.y));
		double result = 1 / (double)(deltaPosition.x + deltaPosition.y + 1);
		if (result == 1)
			Debug.Log ("TestRoute result=" + result + ",("+position.x+","+position.y+")");
		return result;
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
		fittestDirections = new List<int> ();
		pathTiles = new List<GameObject> ();

		geneticAlgorithm = new GeneticAlgorithm ();
		geneticAlgorithm.mazeController = this;
		geneticAlgorithm.Run ();
	}

	public void ClearPathTiles() {
		foreach (GameObject pathTile in pathTiles) {
			Destroy(pathTile);
		}
		pathTiles.Clear();
	}

	public void RenderFittestChromosomePath() {
		ClearPathTiles ();
		Genome fittestGenome = geneticAlgorithm.genomes[geneticAlgorithm.fittestGenome];
		List<int> fittestDirections = geneticAlgorithm.Decode (fittestGenome.bits);
		Vector2 position = startPosition;

		foreach (int direction in fittestDirections) {
			position = Move (position, direction);
			GameObject pathTile = Instantiate (pathPrefab);
			pathTile.transform.position = new Vector3(position.x, 0, -position.y);
			pathTiles.Add (pathTile);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (geneticAlgorithm.busy) geneticAlgorithm.Epoch ();
		RenderFittestChromosomePath ();
		TextMesh textMesh = text.GetComponent<TextMesh> ();
		Vector3 lastPosition = pathTiles.Last ().transform.position;
		textMesh.text = "Generation: " + geneticAlgorithm.generation + " (" + lastPosition.x + "," + lastPosition.z + ")";
	}
}
