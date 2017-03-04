using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneticAlgorithm {
	public List<Genome> genomes;

	public int populationSize;
	public double crossoverRate;
	public double mutationRate;
	public int chromosomeLength;
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
		return new Genome ();
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
