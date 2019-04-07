using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(Maze))]
public class MazeEditor: PropertyDrawer {
	// Draw the property inside the given rect
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		Maze maze = fieldInfo.GetValue(property.serializedObject.targetObject) as Maze;
		// Using BeginProperty / EndProperty on the parent property means that
		// prefab override logic works on the entire property.
		EditorGUI.BeginProperty(position, label, property);

		// Draw label
		position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

	

		// Calculate rects
		var amountRect = new Rect(position.x, position.y, 50, position.height);
		var unitRect = new Rect(position.x + 55, position.y, 50, position.height);
	
		// Draw fields - passs GUIContent.none to each so they are drawn without labels
		//EditorGUI.PropertyField(amountRect, property.FindPropertyRelative("width"), GUIContent.none);
		//EditorGUI.PropertyField(unitRect, property.FindPropertyRelative("height"), GUIContent.none);


		EditorGUI.EndProperty();
		Debug.Log(maze.walls);
		for(int y = 0; y < maze.height; y++) {
			for(int x = 0; x < maze.width; x++) {
				maze.walls[x, y] = EditorGUI.Toggle(new Rect(position.x, position.y, position.width, 20), maze.walls[x,y]);
			}
		}
		
	}
}
