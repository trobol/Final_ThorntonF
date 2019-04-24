using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InnerEnergy : MonoBehaviour
{

	public Color color1, color2;
	void Start()
	{
		float rand = Random.Range(0, 1);
		GetComponent<Image>().color = Color.Lerp(color1, color2, rand);
	}

}
