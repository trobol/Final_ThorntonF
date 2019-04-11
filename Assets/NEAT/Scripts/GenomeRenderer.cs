using UnityEngine;
using UnityEditor;
using System.Collections;

public class GenomeRenderer : EditorWindow

{
	[MenuItem("NEAT/Genomes")]
	public static void ShowWindow()
	{
		EditorWindow.GetWindow(typeof(GenomeRenderer));
	}
	void OnGUI()
	{
		// The actual window code goes here
	}
}