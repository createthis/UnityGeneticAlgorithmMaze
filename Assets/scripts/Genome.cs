using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Genome {
	public List<int> bits;
	public double fitness;

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
		bits = new List<int> ();
	}
}
