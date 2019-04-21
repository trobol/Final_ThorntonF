
namespace NEAT
{
	//linear representation of a network
	public class Genome
	{
		static System.Random random = new System.Random();

		//chance to mutate weights
		static int mutationChance = 80,
				//chance to uniform preturb each weight
				preturbChance = 90;


		ConnectionGene[] genes;
		ConnectionGene first, last;
		public static int inov = 0;
		public float fitness = 0;
		public int size;
		public Genome(NetworkType nt)
		{
			size = nt.inputs * nt.outputs;
			for (int i = 0; i < nt.inputs; i++)
			{
				for (int o = 0; o < nt.outputs; o++)
				{
					genes[i * nt.inputs + o] = new ConnectionGene(i, o, 1);
				}
			}
		}

		public Genome(Genome g)
		{
			size = g.genes.Length;
			genes = new ConnectionGene[g.genes.Length];
			for (int a = 0; a < g.genes.Length; a++)
			{
				genes[a] = g.genes[a];
			}
		}
		public Genome(int s)
		{
			genes = new ConnectionGene[s];
			size = s;
		}
		public static Genome Mutate(Genome g0)
		{


			Genome g = new Genome(g0);

			for (int i = 0; i < g.size; i++)
			{
				if (random.Next(100) > mutationChance) continue;

				if (random.Next(100) <= preturbChance)
				{
					//uniformly preturb weight
					g.genes[i].weight *= random.NextDouble() - 0.5;
				}
				else
				{
					//change weight to random value
					g.genes[i].weight += random.NextDouble() - 0.5;
				}
			}


			return g;
		}
		public static Genome Crossover(Genome g1, Genome g2)
		{



			Genome g0;
			//g1 = more fit g2 = less fit
			if (g1.fitness < g2.fitness)
			{
				//swap g1 and g2
				g0 = g1;
				g1 = g2;
				g2 = g0;
			}

			//index of the last matching gene
			int maxMatching = 0,
				//highest invation in g1
				maxInov = g1.genes[g1.size - 1].inovation;

			for (int i = 0; i < g1.size; i++)
			{
				if (g1.genes[i].inovation != g2.genes[i].inovation) break;
				maxMatching++;
			}

			bool equalFitness = g1.fitness == g2.fitness;

			int size = equalFitness ? g1.size + (g2.size - maxMatching) : g1.size;

			g0 = new Genome(size);


			for (int i = 0; i < maxMatching; i++)
			{
				g0.genes[i] = random.Next(1) > 0 ? g1.genes[i] : g2.genes[i];
			}
			//add disjoint and exess genes
			if (!equalFitness)
			{
				//add from more fit parent
				for (int i = maxMatching; i < size; i++)
				{

				}
			}
			else
			{
				//add all
				int g1Index = maxMatching,
				 	g2Index = maxMatching;
				for (int i = maxMatching; i < size; i++)
				{

					if (g1Index >= g1.size)
					{
						g0.genes[i] = g2.genes[g2Index];
						g2Index++;
					}
					else if (g2Index >= g2.size)
					{
						g0.genes[i] = g1.genes[g1Index];
						g1Index++;
					}
					else
					{
						//add the gene with the lowest inovation
						int inov1 = g1.genes[g1Index].inovation,
						inov2 = g2.genes[g2Index].inovation;

						if (inov1 > inov2)
						{
							g0.genes[i] = g2.genes[g2Index];
							g2Index++;

						}
						else
						{
							g0.genes[i] = g1.genes[g1Index];
							g1Index++;
						}
					}
				}
			}
			return g0;
		}

	}

}