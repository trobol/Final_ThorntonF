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
		float rand = Random.Range(0, 1f);
		GetComponent<Image>().color = Color.Lerp(color1, color2, rand);
        GetAnimator();
        
    }
    void GetAnimator()
    {
        if (animator == null)
        {
            animator = gameObject.GetComponent<Animator>();
        }
    }
    
    // https://docs.unity3d.com/ScriptReference/Animator.Play.html
    
    public void Activate()
    {
        GetAnimator();
        animator.SetFloat("direction", 1);
        animator.Play("energy", 0, 0);
    }
	public void Deactivate() {
        animator.SetFloat("direction", -1);
        animator.Play("energy", 0, 1);
	}

}
