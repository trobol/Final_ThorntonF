using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
		float randX = Random.Range(-45, 45),
			randY = Random.Range(-45, 45),
			randZ = Random.Range(0, 360);

		transform.Rotate(randX, randY, randZ);

	}

	// Update is called once per frame
	void Update()
	{

	}
}
