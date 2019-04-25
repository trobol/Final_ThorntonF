using System.Collections.Generic;
namespace NEAT
{
	//linear representation of a network
	[System.Serializable]
	public class Genome
	{
		static System.Random random = new System.Random();

		//chance to mutate weights
		static int mutationChance = 80,
				//chance to uniform preturb each weight
				preturbChance = 90;


		public ConnectionGene[] connections;
		NodeGene[] nodes;
		public static int inov = 0;
		public float fitness = 0;
		public int size, nodeCount = 0;
		public NetworkType type;
		public Genome(NetworkType nt)
		{
			type = nt;
			size = nt.inputs * nt.outputs;
			for (int i = 0; i < nt.inputs; i++)
			{
				for (int o = 0; o < nt.outputs; o++)
				{
					connections[i * nt.inputs + o] = new ConnectionGene(i, nt.inputs + o, 1);
				}
			}
			BuildNodes();
		}

		public Genome(Genome g)
		{

			size = g.connections.Length;
			connections = new ConnectionGene[g.connections.Length];
			for (int a = 0; a < g.connections.Length; a++)
			{
				connections[a] = g.connections[a];
			}
		}
		public Genome(int s)
		{
			connections = new ConnectionGene[s];
			size = s;
		}
		public Genome(ref ConnectionGene[] cg, NetworkType nt)
		{
			size = cg.Length;
			connections = cg;
			type = nt;
			BuildNodes();
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
					g.connections[i].weight *= random.NextDouble() - 0.5;
				}
				else
				{
					//change weight to random value
					g.connections[i].weight += random.NextDouble() - 0.5;
				}
			}


			return g;
		}
		public static Genome Crossover(Genome g1, Genome g2)
		{
			//g1 = more fit g2 = less fit
			if (g1.fitness < g2.fitness)
			{
				//swap g1 and g2
				Genome g0 = g1;
				g1 = g2;
				g2 = g0;
			}

			//index of the last matching gene
			int maxMatching = 0,
				//highest invation in g1
				maxInov = g1.connections[g1.size - 1].inovation;

			for (int i = 0; i < g1.size; i++)
			{
				if (g1.connections[i].inovation != g2.connections[i].inovation) break;
				maxMatching++;
			}

			bool equalFitness = g1.fitness == g2.fitness;

			int size = equalFitness ? g1.size + (g2.size - maxMatching) : g1.size;

			ConnectionGene[] resultConnections = new ConnectionGene[size];



			for (int i = 0; i < maxMatching; i++)
			{
				resultConnections[i] = random.Next(1) > 0 ? g1.connections[i] : g2.connections[i];
			}
			//add disjoint and exess connections
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
						resultConnections[i] = g2.connections[g2Index];
						g2Index++;
					}
					else if (g2Index >= g2.size)
					{
						resultConnections[i] = g1.connections[g1Index];
						g1Index++;
					}
					else
					{
						//add the gene with the lowest inovation
						int inov1 = g1.connections[g1Index].inovation,
						inov2 = g2.connections[g2Index].inovation;

						if (inov1 > inov2)
						{
							resultConnections[i] = g2.connections[g2Index];
							g2Index++;

						}
						else
						{
							resultConnections[i] = g1.connections[g1Index];
							g1Index++;
						}
					}
				}
			}
			return new Genome(ref resultConnections, g1.type);
		}

	}

}