using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidFragment : MonoBehaviour
{

	public static float speed = 0.05f;

	float time = 1;
	float direction;
	void Start() {
		direction = Random.Range(-1, 1);
	}
	void Update()
	{
		time += Time.deltaTime;
		transform.localScale += time * Vector3.one * speed * direction;
	}
}
