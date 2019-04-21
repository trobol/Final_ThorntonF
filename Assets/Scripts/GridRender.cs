using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridRender : MonoBehaviour
{



	public Grid grid;

	public GameObject tilesParent, objectsParent;
	public GameObject[,] objects, tiles;

	void Start()
	{
		grid.render = this;

	}

	public void SpawnTiles(GameObject tile)
	{
		tilesParent = new GameObject("Tiles");
		objectsParent = new GameObject("Objects");
		tilesParent.transform.parent = transform;
		objectsParent.transform.parent = transform;

		GameObject asteroidPrefab = Resources.Load<GameObject>("Asteroid"),
			playerPrefab = Resources.Load<GameObject>("Player"),
			alienPrefab = Resources.Load<GameObject>("Alien");

		objects = new GameObject[grid.width, grid.height];

		for (int x = 0; x < grid.width; x++)
		{
			for (int y = 0; y < grid.height; y++)
			{
				Instantiate(tile, new Vector3(x, y, 0), Quaternion.identity, tilesParent.transform);
				Grid.Type type = grid.Get(x, y);


				GameObject g;
				switch (type)
				{
					case Grid.Type.Asteroid:
						g = asteroidPrefab;
						break;
					case Grid.Type.Player:
						g = playerPrefab;
						break;
					case Grid.Type.Alien:
						g = alienPrefab;
						break;
					default:
						continue;
				}

				objects[x, y] = Instantiate(g, new Vector3(x, y, 0), Quaternion.identity, objectsParent.transform);
			}
		}
	}

	void Update()
	{

	}

	public void UpdateGrid()
	{

	}
}
