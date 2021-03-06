﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

	public Grid grid;
	public GameObject[,] asteroids;
	public int width, height;

	public HudController hud;

	GameObject player, alien;
	public GridTile playerTile, alienTile;
	GameObject asteroidPrefab;

	public GridRender gridRender;
	void Awake()
	{
		grid = new Grid(width, height);

		Camera.main.transform.position = new Vector3(width / 2, height / 2, -10);

		gridRender = Instantiate(Resources.Load<GameObject>("GridRender")).GetComponent<GridRender>();

		gridRender.grid = grid;
		BuildGrid();
		gridRender.SpawnTiles(Resources.Load<GameObject>("Tile"));
		player = Resources.Load<GameObject>("Player");
		alien = Resources.Load<GameObject>("Alien");

		asteroidPrefab = Resources.Load<GameObject>("Asteroid");


		asteroids = gridRender.objects;

		hud = Instantiate(Resources.Load<GameObject>("HUD")).GetComponent<HudController>();

	}

	void BuildGrid()
	{

		int pX = Random.Range(0, width),
			pY = Random.Range(0, height);

		playerTile = new GridTile(grid, Grid.Type.Player, pX, pY);


		int aX = Random.Range(0, width),
			aY = Random.Range(0, height);
		while (aX == pX)
		{
			aX = Random.Range(0, width);
		}
		alienTile = new GridTile(grid, Grid.Type.Alien, aX, aY);


		for (int x = 0; x < grid.width; x++)
		{
			for (int y = 0; y < grid.height; y++)
			{
				if ((x == pX && y == pY) || (x == aX && y == aY)) continue;
				if (Random.Range(0, 2) > ((new Vector2(x, y) / new Vector2(grid.width, grid.height)) - Vector2.one).magnitude)
				{
					grid.Set(x, y, Grid.Type.Asteroid);
				}
			}
		}
	}
}
