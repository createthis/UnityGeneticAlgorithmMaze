using System;
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
		for (int i = 0; i < bits.Count; i++) {
			// flip this bit?
			if (UnityEngine.Random.value < mutationRate) {
				// flip the bit
				bits [i] = bits [i] == 0 ? 1 : 0;
			}
		}
	}

	public void Crossover(List<int> mom, List<int> dad, List<int> baby1, List<int> baby2) {
		if (UnityEngine.Random.value > crossoverRate || mom == dad) {
			baby1 = mom;
			baby2 = dad;

			return;
		}

		System.Random rnd = new System.Random ();

		int crossoverPoint = rnd.Next (0, chromosomeLength - 1);

		for (int i = 0; i < crossoverPoint; i++) {
			baby1.Add (mom [i]);
			baby2.Add (dad [i]);
		}

		for (int i = crossoverPoint; i < mom.Count; i++) {
			baby1.Add (dad [i]);
			baby2.Add (mom [i]);
		}
	}

	public Genome RouletteWheelSelection() {
		double slice = UnityEngine.Random.value * totalFitnessScore;
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
		for (int i = 0; i < populationSize; i++) {
			genomes [i].CalculateFitness ();
		}
	}

	public List<int> Decode(List<int> bits) {
		return new List<int> ();
	}

	public int BinToInt(List<int> value) {
		return 0;
	}

	public void CreateStartPopulation() {
		for (int i = 0; i < populationSize; i++) {
			Genome baby = new Genome (chromosomeLength);
			genomes.Add (baby);
		}
	}

	public void Run() {
	}

	public void Epoch() {
		UpdateFitnessScores ();

		int numberOfNewBabies = 0;

		List<Genome> babies = new List<Genome> ();
		while (numberOfNewBabies < populationSize) {
			// select 2 parents
			Genome mom = RouletteWheelSelection ();
			Genome dad = RouletteWheelSelection ();
			Genome baby1 = new Genome(chromosomeLength);
			Genome baby2 = new Genome(chromosomeLength);
			Crossover (mom.bits, dad.bits, baby1.bits, baby2.bits);
			Mutate (baby1.bits);
			Mutate (baby2.bits);
			babies.Add (baby1);
			babies.Add (baby2);

			numberOfNewBabies += 2;
		}

		// overwrite population with babies
		genomes = babies;

		// increment the generation counter
		generation++;
	}
}
