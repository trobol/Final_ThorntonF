using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


	public int energy = 5, energyPool = 5;
	public GameObject radar;
	GridManager gridManager;
	void Start()
	{
		rotTarget = transform.rotation;
		moveTarget = transform.position;
		radar = transform.Find("Radar").gameObject;
		gridManager = GameObject.Find("GridManager").GetComponent<GridManager>();
	}


	void Update()
	{
		GetInput();
		Rotate(0);
		MoveLerp();
	}

	void BeginTurn()
	{

	}
	void GetInput()
	{
		if (Input.GetKeyDown(KeyCode.W))
		{
			Move();
		}
		else if (Input.GetKeyDown(KeyCode.A))
		{
			Rotate(1);
		}
		else if (Input.GetKeyDown(KeyCode.D))
		{
			Rotate(-1);
		}

	}

	public float rotTime = 0;
	public float rotSpeed = 2;
	public Quaternion rotTarget;
	void Rotate(int direction)
	{

		if (direction == 0)
		{
			if (rotTime <= 0) return;
			rotTime -= Time.deltaTime * rotSpeed;
			Quaternion rot = Quaternion.Lerp(transform.rotation, rotTarget, 1 - rotTime);
			transform.rotation = rot;
			radar.transform.localRotation = Quaternion.Inverse(rot);
		}
		else
		{
			rotTime = 1;
			rotTarget = rotTarget * Quaternion.AngleAxis(90 * direction, Vector3.forward);
		}


	}


	public float moveTime = 0;
	public float moveSpeed = 2;
	Vector3 moveTarget;
	void Move()
	{
		Vector3 target = moveTarget + rotTarget * Vector3.up * -1;
		if (energy > 0 && CanMove(target))
		{
			moveTime = 1;
			moveTarget = target;
			energy--;
		}

	}
	void MoveLerp()
	{
		if (moveTime > 0)
		{
			moveTime -= Time.deltaTime * moveSpeed;
			transform.position = Vector3.Lerp(transform.position, moveTarget, 1 - moveTime);
			//radar.transform.localScale = Vector3.Lerp(radar.transform.localScale, Vector3.one * energy, 1 - moveTime);
		}
	}

	bool CanMove(Vector3 t)
	{
		int x = Mathf.RoundToInt(t.x),
		y = Mathf.RoundToInt(t.y);
		return gridManager.asteroids[x, y] == null;
	}
}
