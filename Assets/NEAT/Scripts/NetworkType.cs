namespace NEAT
{

	public class NetworkType {
		string name;
		int generations;
		NetworkList[] generation;
		public NetworkType(string n, int gens, NetworkList g) {
			name = n;
			generations = gens;
			generation = g;
		}
	}

	public static class NetworkLoader {
		static NetworkType Load(string name) {


		}
	}

	public class NetworkList {

	}
}