using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
	public int range = 5;
	public float animationTime = 0.5f, endTime = 0.3f;
    PlayerMovement player;
	GameObject[] laserSections;
    SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start()
	{
		GameObject laserPrefab = Resources.Load<GameObject>("Laser Section");
		laserSections = new GameObject[range];
		for (int i = 0; i < range; i++)
		{
			laserSections[i] = Instantiate(laserPrefab, transform);
			laserSections[i].transform.position = transform.parent.position + Vector3.up * (-i - 1);
			laserSections[i].SetActive(false);
		}
        player = transform.parent.GetComponent<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{

	}
	int distance = 5;
	public void Show(int d)
	{
		distance = d;
		StartCoroutine("ShootLaser");
        spriteRenderer.enabled = true;
	}


	IEnumerator ShootLaser() {
		for(int i = 0; i < distance; i++) {
			laserSections[i].SetActive(true);
			yield return new WaitForSeconds(animationTime);
		}
        yield return new WaitForSeconds(endTime);
        for (int i = 0; i < distance; i++)
        {
            laserSections[i].SetActive(false);
           
        }
        player.EndShoot();
        spriteRenderer.enabled = false;
    }
}
