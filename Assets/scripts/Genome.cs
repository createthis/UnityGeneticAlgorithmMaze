using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Genome {
	public List<int> bits;
	public double fitness;
	public Vector2 position;
	private Vector2 endPosition;

	public Genome() {
		Initialize ();
	}

	public Genome(int numBits) {
		Initialize ();

		for (int i = 0; i < numBits; i++) {
			System.Random rnd = new System.Random ();

			bits.Add (rnd.Next (0, 1));
		}
	}

	private void Initialize() {
		fitness = 0;
		endPosition = new Vector2 (0, 2);
	}

	public double CalculateFitness() {
		int deltaX = Math.Abs ((int)(position.x - endPosition.x));
		int deltaY = Math.Abs ((int)(position.y - endPosition.y));

		return 1 / (double)(deltaX + deltaY + 1);
	}
}
