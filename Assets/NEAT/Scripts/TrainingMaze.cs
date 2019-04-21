using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingMaze
{
	public TrainingMaze()
	{
		gridRender = GameObject.Instantiate(Resources.Load<GameObject>("GridRender")).GetComponent<GridRender>();
	}

	public Grid grid;
	public GridRender gridRender;


	void GenerateMaze()
	{

	}
}
