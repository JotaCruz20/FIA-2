using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class TournamentSelection : SelectionMethod
{
	private int tournamentSize;

	public TournamentSelection(int tournamentSize) : base()
	{
		this.tournamentSize = tournamentSize;
	}

	public override List<Individual> selectIndividuals(List<Individual> oldpop, int num)
	{
		if (oldpop.Count < tournamentSize)
		{
			throw new System.Exception("The population size is smaller than the tournament size.");
		}

		List<Individual> selectedInds = new List<Individual>();
		for (int i = 0; i < num; i++)
		{
			selectedInds.Add(tournamentSelection(oldpop,tournamentSize).Clone());
		}

		return selectedInds;
	}

	public Individual tournamentSelection(List<Individual> population, int tournamentSize)
	{
		//* YOUR CODE HERE *//
		Individual best = null;
		for (int i = 0; i < tournamentSize; i++)
		{
			Individual individual = population[Random.Range(0, population.Count - 1)].Clone();
			if (best == null || individual.Fitness > best.Fitness)
			{
				best = individual.Clone();
			}
		}

		return best;
	}
}
