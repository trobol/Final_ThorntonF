using UnityEngine;
using UnityEditor;
using System.Collections;

public class NetworkList : EditorWindow

{
	Network selectedNetwork;
	string myString = "Hello World";
	bool groupEnabled;
	bool myBool = true;
	float myFloat = 1.23f;
	[MenuItem("NEAT/Networks")]
	public static void ShowWindow()
	{
		EditorWindow.GetWindow(typeof(NetworkList));
	}
	void OnGUI()
	{
		GUILayout.Label("Base Settings", EditorStyles.boldLabel);
		myString = EditorGUILayout.TextField("Text Field", myString);

		groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
		myBool = EditorGUILayout.Toggle("Toggle", myBool);
		myFloat = EditorGUILayout.Slider("Slider", myFloat, -3, 3);
		EditorGUILayout.EndToggleGroup();
	}
}