using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NEAT
{
	public class Network
	{
		Node[] nodes;
		Connection[] connections;
		Network(Genome g)
		{
			List<Node> nodeList = new List<Node>(g.type.inputs + g.type.inputs);
			connections = new Connection[g.size];

			//Add input and output node (0 -> type.inputs + type.outputs)
			int a = g.type.inputs + g.type.outputs;
			for (int i = 0; i < a; i++)
			{
				Node.Type t = i < g.type.inputs ? Node.Type.input : Node.Type.output;

				nodeList.Add(new Node(i, t));
			}
			for (int b = 0; b < g.size; b++)
			{
				connections[b] = new Connection(g.connections[b], ref nodeList);

			}


			nodes = nodeList.ToArray();


		}

		//nodeList should always be sorted

	}

	public class Connection
	{
		public Node input, output;
		public double weight;
		public Connection(Node i, Node o, float w)
		{
			input = i;
			output = o;
			weight = w;
		}
		public Connection(ConnectionGene gene, ref List<Node> nodeList)
		{
			output = FindNode(gene.output, ref nodeList);
			input = FindNode(gene.input, ref nodeList);
			output.inputCount++;
			input.outputCount++;
			weight = gene.weight;
		}
		Node FindNode(int id, ref List<Node> nodeList)
		{
			//empty list
			if (nodeList.Count <= 0)
			{
				nodeList.Add(new Node(id, Node.Type.hidden));
				return nodeList[0];
			}
			for (int i = 0; i < nodeList.Count; i++)
			{
				//existing node found
				if (id == nodeList[i].id)
				{
					return nodeList[i];
				}
				//list does not contain node
				else if (id > nodeList[i].id)
				{
					nodeList.Insert(i, new Node(id, Node.Type.hidden));
					return nodeList[i];
				}
			}
			//node id is smaller then all nodes in list
			nodeList.Insert(0, new Node(id, Node.Type.hidden));
			return nodeList[0];
		}
	}
	public class Node
	{
		public Type type;
		public int id;
		float value;
		public int inputCount = 0, outputCount = 0;
		public Connection[] inputs, outputs;
		public enum Type
		{
			input, output, hidden
		}
		public Node(int id, Type t)
		{

		}
	}

}
