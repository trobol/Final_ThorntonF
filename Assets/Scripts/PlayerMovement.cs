using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	
	public int energy = 5, energyPool = 5;
	public GameObject radar;
	void Start () {
		rotTarget = transform.rotation;
		moveTarget = transform.position;
		radar = transform.Find("Radar").gameObject;
	}
	
	
	void Update () {
		GetInput();
		Rotate(0);
		MoveLerp();
	}	

	void BeginTurn() {

	}
	void GetInput() {
		if (Input.GetKeyDown(KeyCode.W))
		{
			Move();
		} else if(Input.GetKeyDown(KeyCode.A)) {
			Rotate(1);
		} else if(Input.GetKeyDown(KeyCode.D)) {
			Rotate(-1);
		}
		
	}

	public float rotTime = 0;
	public float rotSpeed = 2;
	public Quaternion rotTarget;
	void Rotate(int direction) {

		if(direction == 0) {
			if(rotTime <= 0) return;
			rotTime -= Time.deltaTime * rotSpeed;
			transform.rotation = Quaternion.Lerp(transform.rotation, rotTarget, 1-rotTime);
			
		} else  {
			rotTime = 1;
			rotTarget = rotTarget * Quaternion.AngleAxis(90 * direction, Vector3.forward);
		}
		
		
	}


	public float moveTime = 0;
	public float moveSpeed = 2;
	Vector3 moveTarget;
	void Move()
	{
		if(energy > 0) {
			moveTime = 1;
			moveTarget = moveTarget + rotTarget * Vector3.up * -1;
			energy--;
		}
		
	}
	void MoveLerp() {
		if(moveTime > 0) {
			moveTime -= Time.deltaTime * moveSpeed;
			transform.position = Vector3.Lerp(transform.position, moveTarget, 1-moveTime);
			radar.transform.localScale = Vector3.Lerp(radar.transform.localScale, Vector3.one * energy, 1-moveTime);
		}
	}
}
