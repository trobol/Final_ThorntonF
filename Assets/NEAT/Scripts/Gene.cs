namespace NEAT
{
	//a connection between two nodes
	public class ConnectionGene
	{
		public int input, //input NodeGene index in Genome
		output; //output NodeGene index in Genome
		public double weight;
		public bool enabled = true;
		public int inovation;
		static public int inovationNum = 1;
		public ConnectionGene(int input, int output, double weight)
		{
			this.input = input;
			this.output = output;
			this.weight = weight;
			this.inovation = inovationNum++;
		}


	}
	public class NodeGene
	{
		public int id;
		public ConnectionGene[] inputs, outputs;
		public int inputCount, outputCount;
		public NodeType type;
		public NodeGene(int i)
		{
			id = i;
		}
	}
}