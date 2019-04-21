using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Grid
{
	public int width, height;
	public Type[,] grid;


	public GridRender render;
	public Grid(int w, int h)
	{
		grid = new Type[w, h];
		width = w;
		height = h;
		for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++)
			{
				grid[x, y] = Type.None;
			}
		}
	}

	public enum Type
	{
		None = 0,
		Asteroid = 1,
		Alien = 2,
		Player = 3
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
		return grid[x, y] == Type.None;
	}

	public void UpdateRender()
	{
		if (render == null) return;

		render.UpdateGrid();
	}

	public int[] AsArray()
	{
		int[] a = new int[width * height];
		for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++)
			{
				a[height * x + y] = (int)grid[x, y];
			}
		}
		return a;
	}


}