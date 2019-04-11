namespace NEAT
{
	//a connection between two nodes
	public class Gene
	{
		
	}

	public class ConnectionGene : Gene {
		public int input, //input NodeGene index in Genome
		output; //output NodeGene index in Genome
		public float weight;
		public bool enabled = true;
		public int inovationNum;
		
		public ConnectionGene(int input, int output, float weight, int inov)
		{
			this.input = input;
			this.output = output;
			this.weight = weight;
			this.inovationNum = inov;
		}
		
	}

	public class NodeGene : Gene {

	}
}