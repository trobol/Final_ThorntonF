using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidFragment : MonoBehaviour
{

	public float speed;

	float time = 1;
	void Update()
	{
		time += Time.deltaTime;
		transform.localScale += time * Vector3.one * speed;
	}
}
