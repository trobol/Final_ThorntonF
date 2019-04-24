using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InnerEnergy : MonoBehaviour
{

	public Color color1, color2;
	Animator animator;
	void Start()
	{
		float rand = Random.Range(0, 1);
		GetComponent<Image>().color = Color.Lerp(color1, color2, rand);
		animator = GetComponent<Animator>();
		animator.Play("energy", 1, 0f);
	}
	public void Drain() {
		animator.Play("energy", -1, 0f);
		Invoke("TurnOff", 1f);
	}
	void TurnOff() {
		gameObject.SetActive(false);
	}
}
