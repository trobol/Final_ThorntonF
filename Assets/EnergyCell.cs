using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyCell : MonoBehaviour
{

	public GameObject inner;
	public void Activate(float delay)
	{
		Invoke("ActivateInner", delay);
	}
	public void Deactivate()
	{
		inner.SetActive(false);
	}
	void ActivateInner()
	{
		inner.SetActive(true);
	}
}
