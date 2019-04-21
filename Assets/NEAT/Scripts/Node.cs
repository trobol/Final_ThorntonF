namespace NEAT
{
	public class Node
	{
		NodeType type;
		int id;
		float value;
	}
	public enum NodeType
	{
		input, output, hidden
	}
}
