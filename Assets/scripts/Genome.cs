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
            		System.Random randomNumberGen = new System.Random(DateTime.Now.GetHashCode() * SystemInfo.processorFrequency.GetHashCode());

		        bits.Add(randomNumberGen.Next(0, 2));
		}
	}

	private void Initialize() {
		fitness = 0;
		bits = new List<int> ();
	}
}
