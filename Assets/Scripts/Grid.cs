using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Grid
{
	public int width, height;
	public Type[,] grid;
	public Grid(int w, int h)
	{
		grid = new Type[w, h];
		width = w;
		height = h;
		for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++)
			{
				grid[x, y] = Type.Empty;
			}
		}
	}

	public enum Type
	{
		Empty = 1,
		Player = 2,
		Alien = 3,
		Asteroid = 4
	}

	public void Set(int x, int y, Type t)
	{
		grid[x, y] = t;
	}
	public Type Get(int x, int y)
	{
		return grid[x, y];
	}
	public bool IsEmpty(int x, int y)
	{
		return grid[x, y] == Type.Empty;
	}

}
