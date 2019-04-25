using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidExplode : MonoBehaviour
{
	float destroyTime = 2f;
	public float force = 1f;
	void Start()
	{
		for (int i = 0; i < transform.childCount; i++)
		{
			GameObject o = transform.GetChild(i).gameObject;
			Vector3 p = o.transform.localPosition;


			o.GetComponent<Rigidbody2D>().velocity = p.normalized * Random.Range(0.5f, 4f) * force;

			Destroy(o, destroyTime);
		}
		Destroy(gameObject, destroyTime);
	}
}
