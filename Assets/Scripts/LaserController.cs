using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
	public int range = 5;
	GameObject[] laserSections;


	// Use this for initialization
	void Start()
	{
		GameObject laserPrefab = Resources.Load<GameObject>("Laser Section");
		laserSections = new GameObject[range];
		for (int i = 0; i < range; i++)
		{
			laserSections[i] = Instantiate(laserPrefab, transform);
			laserSections[i].transform.position = transform.parent.position + Vector3.up * (-i - 1);
		}
		Show(5);
	}

	// Update is called once per frame
	void Update()
	{

	}

	void Show(int distance)
	{

	}
}
