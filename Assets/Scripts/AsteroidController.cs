using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{

    GameObject explodePrefab, effectPrefab;

    void Start()
	{
		float randX = Random.Range(-45, 45),
			randY = Random.Range(-45, 45),
			randZ = Random.Range(0, 360);

		transform.Rotate(randX, randY, randZ);
        float randScale = Random.Range(0.35f, 0.6f);
        transform.localScale = Vector3.one * randScale;
        explodePrefab = Resources.Load<GameObject>("asteroid_explode");
        effectPrefab = Resources.Load<GameObject>("explode");
    }

   
    public void BlowUp()
    {
        GameObject o = Instantiate(explodePrefab, transform.position, transform.rotation);
        Instantiate(effectPrefab, transform.position, Quaternion.identity);
        o.transform.localScale = transform.localScale;
        Destroy(gameObject);
    }
}
