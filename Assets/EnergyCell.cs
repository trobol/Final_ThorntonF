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
	public void Deactivate(float delay)
	{
		//Invoke("DeactivateInner", delay);
		inner.SetActive(false);
	}
	void DeactivateInner() {

	}
	void ActivateInner()
	{
		inner.SetActive(true);
	}
}
