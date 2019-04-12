using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
namespace NEAT
{

	public class NetworkType
	{
		public string name = "Untitled";
		public int genSize = 100;
		private static string baseDirectory = Application.dataPath + "/NEAT/Networks/";
		public bool SetName(string value)
		{
			if (value == name) return true;
			string directoryPath = baseDirectory + value;


			if (!Directory.Exists(directoryPath))
			{
				name = value;
				return true;
			}


			return false;
		}

		public int inputs = 1, outputs = 1;
		public int generations;
		public bool trained = false;

		List<Genome[]> generation;
		public NetworkType(string n, int gens)
		{
			name = n;
			generations = gens;
		}
		public NetworkType() { }
		public NetworkType(NetworkType n)
		{
			name = n.name + " Copy";
			inputs = n.inputs;
			outputs = n.outputs;
		}
		public void Save()
		{
			string directoryPath = baseDirectory + name;
			if (!Directory.Exists(directoryPath))
			{
				Directory.CreateDirectory(directoryPath);
			}

			string dataAsJson = JsonUtility.ToJson(this);

			File.WriteAllText(directoryPath + "/data.json", dataAsJson);
		}


		public static NetworkType Load(string n)
		{
			string filePath = baseDirectory + n + "/data.json";

			if (File.Exists(filePath))
			{
				string dataAsJson = File.ReadAllText(filePath);
				return JsonUtility.FromJson<NetworkType>(dataAsJson);
			}
			return null;
		}
		public static NetworkType LoadPath(string path)
		{
			if (File.Exists(path + "/data.json"))
			{
				string dataAsJson = File.ReadAllText(path + "/data.json");
				return JsonUtility.FromJson<NetworkType>(dataAsJson);
			}

			return null;
		}
		public static void LoadList()
		{
			string[] directories = Directory.GetDirectories(baseDirectory);
			networkTypes = new NetworkType[directories.Length];
			for (int i = 0; i < directories.Length; i++)
			{

				networkTypes[i] = LoadPath(directories[i]);
			}
		}

		public static NetworkType[] networkTypes;

	}
}