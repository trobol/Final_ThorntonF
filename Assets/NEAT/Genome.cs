namespace NEAT
{
	//representation of a network
	//
	public class Genome
	{
		Gene[] connections;
		public static int inov;
		public Genome(int input, int output)
		{
			connections = new Gene[input * output];
			for (int a = 0; a < input; a++)
			{
				for (int b = 0; b < output; b++)
				{
					connections[(a * output) + b] = new Gene(a, b, 1, inov++);
				}
			}
		}
	}
}