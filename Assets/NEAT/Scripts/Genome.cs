namespace NEAT
{
	//linear representation of a network
	public class Genome
	{
		Gene[] genes;
		public static int inov;
		public Genome(int inputs, int outputs)
		{
			int nodeCount = inputs + outputs;
			genes = new Gene[nodeCount + inputs * outputs];
			for(int n = 0; n < nodeCount; n++) {
				genes[n] = new NodeGene();
			}
			for (int a = 0; a < inputs; a++)
			{
				
				for (int b = 0; b < outputs; b++)
				{
					genes[(a * outputs) + b+nodeCount] = new ConnectionGene(a, b, 1, inov++);
				}
			}
		}

	}
}