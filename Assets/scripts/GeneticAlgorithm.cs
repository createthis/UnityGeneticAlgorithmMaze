using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneticAlgorithm {
	public List<Genome> genomes;

	public int populationSize = 140;
	public double crossoverRate = 0.7f;
	public double mutationRate = 0.001f;
	public int chromosomeLength = 70;
	public int geneLength;
	public int fittestGenome;
	public double bestFitnessScore;
	public double totalFitnessScore;
	public int generation;
	public MazeController mazeController;
	public MazeController mazeControllerDisplay;
	public bool busy;

	public void Mutate(List<int> bits) {
	}

	public void Crossover(List<int> mom, List<int> dad, List<int> baby1, List<int> baby2) {
	}

	public Genome RouletteWheelSelection() {
		double slice = Random.value * totalFitnessScore;
		double total = 0;
		int selectedGenome = 0;

		for (int i = 0; i < populationSize; i++) {
			total += genomes [i].fitness;

			if (total > slice) {
				selectedGenome = i;
				break;
			}
		}
		return genomes[selectedGenome];
	}

	public void UpdateFitnessScores() {
	}

	public List<int> Decode(List<int> bits) {
		return new List<int> ();
	}

	public int BinToInt(List<int> value) {
		return 0;
	}

	public void CreateStartPopulation() {
	}

	public void Run() {
	}

	public void Epoch() {
	}


}
