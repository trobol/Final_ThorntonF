using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

	public Grid grid;
	public GameObject[,] asteroids;
	public int width, height;

	GameObject player, alien;

	GameObject tiles, objects;
	GameObject asteroidPrefab;

	void Awake()
	{
		grid = new Grid(width, height);

		Camera.main.transform.position = new Vector3(width / 2, height / 2, -10);
		tiles = new GameObject("Tiles");
		objects = new GameObject("Objects");
		tiles.transform.parent = transform;
		objects.transform.parent = transform;


		player = Resources.Load<GameObject>("Player");
		alien = Resources.Load<GameObject>("Alien");

		asteroidPrefab = Resources.Load<GameObject>("Asteroid");
		BuildGrid();
	}

	void BuildGrid()
	{
		GameObject tile = Resources.Load<GameObject>("Tile");
		asteroids = new GameObject[width, height];
		for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++)
			{
				Instantiate(tile, new Vector3(x, y, 0), Quaternion.identity, tiles.transform);
			}
		}

		int pX = Random.Range(0, width),
			pY = Random.Range(0, height);

		grid.Set(pX, pY, Grid.Type.Player);
		player = Instantiate(player, new Vector3(pX, pY, 0), Quaternion.identity);


		int aX = Random.Range(0, width),
			aY = Random.Range(0, height);
		while (aX == pX)
		{
			aX = Random.Range(0, width);
		}
		grid.Set(aX, aY, Grid.Type.Alien);
		alien = Instantiate(alien, new Vector3(aX, aY, 0), Quaternion.identity);

		SpawnAsteroids();
	}

	void SpawnAsteroids()
	{
		for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++)
			{
				if (Random.Range(0, 2) > ((new Vector2(x, y) / new Vector2(width, height)) - Vector2.one).magnitude)
				{
					asteroids[x, y] = Instantiate(asteroidPrefab, new Vector3(x, y, 0), Quaternion.identity);
				}
			}
		}
	}

}
