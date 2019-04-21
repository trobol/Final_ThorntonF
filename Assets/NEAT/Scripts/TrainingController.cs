using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NEAT;
public static class TrainingController
{
	[Range(1, 100)]
	public static int framesPerCycle = 1;

	public static NetworkType networkType;

	public static Grid grid;

	public static GridRender gridRender;

	public static NetworkType nt;
	public static bool training;
	public static void Start(NetworkType n)
	{
		nt = n;
		training = true;

	}
	public static void Stop()
	{
		training = false;
	}

	/*
		
	*/
}
