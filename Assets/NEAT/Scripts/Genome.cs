namespace NEAT
{
	//linear representation of a network
	public class Genome
	{
		Gene[] genes;
		Gene first, last;
		public static int inov;
		public float fitness;
		public Genome(int inputs, int outputs)
		{

		}
		public Genome(NetworkType nt)
		{

		}

		public void BuildDefault(int inputs, int outputs)
		{
			int nodeCount = inputs + outputs;
			genes = new Gene[nodeCount + inputs * outputs];
			for (int n = 0; n < nodeCount; n++)
			{
				genes[n] = new NodeGene();
			}
			for (int a = 0; a < inputs; a++)
			{

				for (int b = 0; b < outputs; b++)
				{
					genes[(a * outputs) + b + nodeCount] = new ConnectionGene(a, b, 1, inov++);
				}
			}
		}
		public void Add(Gene g)
		{
			last.next = g;
			last = g;
		}
	}
}