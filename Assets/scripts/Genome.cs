using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Genome {
	public List<int> bits;
	public double fitness;

	public Genome() {
		fitness = 0;
	}

	public Genome(int numBits) {
		fitness = 0;
		for (int i = 0; i < numBits; i++) {
			System.Random rnd = new System.Random ();

			bits.Add (rnd.Next (0, 1));
		}
	}
}
