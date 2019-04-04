namespace NEAT
{
	//a connection between two nodes
	public class Gene
	{
		public int input, output;
		public float weight;
		public bool enabled = true;
		public int inovationNum;

		public Gene(int input, int output, float weight, int inov)
		{
			this.input = input;
			this.output = output;
			this.weight = weight;
			this.inovationNum = inov;
		}
	}
}