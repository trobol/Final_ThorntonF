using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyCell : MonoBehaviour
{

	public InnerEnergy inner;
    public bool activated = false;
   
    public void Activate(float delay)
	{
        if (!activated)
        {
            Invoke("ActivateInner", delay);
        }
        activated = true;
    }
	public void Deactivate(float delay)
	{
        if (activated)
        {

            DeactivateInner();
            activated = false;
        }
    }
	void DeactivateInner() {
        inner.Deactivate();
	}
	void ActivateInner()
	{
        inner.Activate();
	}
    public void Anim(float delay)
    {
        Invoke("StartAnim", delay);
    }
    void StartAnim() 
    {
        GetComponent<Animator>().enabled = true;
    }
}
