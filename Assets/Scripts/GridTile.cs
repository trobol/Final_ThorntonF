using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile
{

	public Grid.Type type;
	public int x, y;
	public GameObject gameObject;
	Grid grid;

	public GridTile(Grid g, Grid.Type t, int x, int y)
	{
		grid = g;
		this.x = x;
		this.y = y;
		type = t;
		grid.Set(x, y, t);
	}

	public void Move(int x, int y)
	{
		grid.Set(this.x, this.y, Grid.Type.None);
		this.x = x;
		this.y = y;
		grid.Set(x, y, type);
	}
	public void Move(Vector3 v)
	{

		grid.Set(this.x, this.y, Grid.Type.None);

		this.x = (int)Mathf.Round(v.x); ;
		this.y = (int)Mathf.Round(v.y); ;
		grid.Set(x, y, type);
	}
}
