[System.Serializable]
public class Maze
{
	//public int[] grid;
	public bool[,] walls = new bool[10, 10];

	public int[] shipPos = new int[2], goalPos = new int[2];

	public int width = 10, height = 10;
	public Maze(int width, int height)
	{
		this.width = width;
		this.height = height;

	}

	public int[] GetGrid()
	{
		int[] grid = new int[width * height];
		for (int y = 0; y < height; y++)
		{
			for (int x = 0; x < width; x++)
			{
				grid[y * width + x] = walls[x, y] ? 1 : 0;
			}
		}
		// y pos * width (row) + x pos (col)
		grid[(shipPos[1] * width) + shipPos[0]] = 2;
		grid[(goalPos[1] * width) + goalPos[0]] = 3;
		return grid;
	}


}