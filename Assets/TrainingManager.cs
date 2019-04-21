using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingManager : MonoBehaviour
{
	void Start()
	{
		StartCoroutine("Run");
	}

	IEnumerator Run()
	{
		while (true)
		{
			Debug.Log("Boop");
			yield return StartCoroutine("WaitForFrames");
		}
	}

	IEnumerator WaitForFrames()
	{
		for (int i = 0; i < TrainingController.framesPerCycle; i++)
		{
			yield return null;
		}
	}


}
