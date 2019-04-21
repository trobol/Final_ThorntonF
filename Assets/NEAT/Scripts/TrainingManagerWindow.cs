using UnityEngine;
using UnityEditor;
using System.Collections;
using NEAT;

public class TrainingManagerWindow : EditorWindow

{
	NetworkType loadedType = null;
	NEAT.Network loadedNetwork = null;

	Genome loadedGenome = null;
	GUIStyle networkTypeListStyle = new GUIStyle();
	[MenuItem("NEAT/Training")]
	public static void ShowWindow()
	{
		TrainingManagerWindow window = (TrainingManagerWindow)EditorWindow.GetWindow(typeof(TrainingManagerWindow));
		window.Start();
	}
	public void Start()
	{
		networkTypeListStyle.alignment = TextAnchor.MiddleLeft;

	}

	void OnGUI()
	{
		DrawToolBar();
		DrawLoadedTypes();
		if (!DrawNetworkType()) return;
		DrawGenomeList();
		DrawGenome();
		DrawNetwork();
	}
	void DrawLoadedTypes()
	{
		if (NetworkType.networkTypes == null) return;
		if (!viewNetworkTypes) return;
		GUILayout.BeginVertical(EditorStyles.helpBox);
		foreach (NetworkType nt in NetworkType.networkTypes)
		{
			if (nt == null) continue;
			if (GUILayout.Button(nt.name + "  Inputs:  " + nt.inputs + "  Outputs: ", networkTypeListStyle))
			{
				loadedType = NetworkType.Load(nt.name);

			}
		}
		GUILayout.EndVertical();

	}
	bool DrawNetworkType()
	{
		if (loadedType == null)
		{
			GUILayout.Label("Open or create a NetworkType to View", EditorStyles.boldLabel);
			return false;
		}
		GUILayout.Label("Network Type", EditorStyles.boldLabel);
		loadedType.SetName(EditorGUILayout.DelayedTextField("Name", loadedType.name));
		loadedType.inputs = EditorGUILayout.DelayedIntField("Inputs", loadedType.inputs);
		loadedType.outputs = EditorGUILayout.DelayedIntField("Outputs", loadedType.outputs);

		return true;
	}
	bool viewNetworkTypes = false;
	bool showNetwork = false;
	void DrawNetwork()
	{
		showNetwork = EditorGUILayout.Foldout(showNetwork, "Network Visual", true);
		if (!showNetwork) return;
		if (loadedNetwork == null) return;
		// Begin to draw a horizontal layout, using the helpBox EditorStyle
		GUILayout.BeginHorizontal(EditorStyles.helpBox);


		Rect layoutRectangle = GUILayoutUtility.GetRect(10, 10000, 200, 200);
		if (Event.current.type == EventType.Repaint)
		{
			// If we are currently in the Repaint event, begin to draw a clip of the size of 
			// previously reserved rectangle, and push the current matrix for drawing.
			GUI.BeginClip(layoutRectangle);
			GL.PushMatrix();

			// Clear the current render buffer, setting a new background colour, and set our
			// material for rendering.
			GL.Clear(true, false, Color.black);


			// Start drawing in OpenGL Quads, to draw the background canvas. Set the
			// colour black as the current OpenGL drawing colour, and draw a quad covering
			// the dimensions of the layoutRectangle.
			GL.Begin(GL.QUADS);
			GL.Color(Color.black);
			GL.Vertex3(0, 0, 0);
			GL.Vertex3(layoutRectangle.width, 0, 0);
			GL.Vertex3(layoutRectangle.width, layoutRectangle.height, 0);
			GL.Vertex3(0, layoutRectangle.height, 0);
			GL.End();

			// Start drawing in OpenGL Lines, to draw the lines of the grid.
			GL.Begin(GL.LINES);

			// Store measurement values to determine the offset, for scrolling animation,
			// and the line count, for drawing the grid.
			int offset = (Time.frameCount * 2) % 50;
			int count = (int)(layoutRectangle.width / 10) + 20;

			for (int i = 0; i < count; i++)
			{
				// For every line being drawn in the grid, create a colour placeholder; if the
				// current index is divisible by 5, we are at a major segment line; set this
				// colour to a dark grey. If the current index is not divisible by 5, we are
				// at a minor segment line; set this colour to a lighter grey. Set the derived
				// colour as the current OpenGL drawing colour.
				Color lineColour = (i % 5 == 0 ? new Color(0.5f, 0.5f, 0.5f) : new Color(0.2f, 0.2f, 0.2f));
				GL.Color(lineColour);

				// Derive a new x co-ordinate from the initial index, converting it straight
				// into line positions, and move it back to adjust for the animation offset.
				float x = i * 10 - offset;

				if (x >= 0 && x < layoutRectangle.width)
				{
					// If the current derived x position is within the bounds of the
					// rectangle, draw another vertical line.
					GL.Vertex3(x, 0, 0);
					GL.Vertex3(x, layoutRectangle.height, 0);
				}

				if (i < layoutRectangle.height / 10)
				{
					// Convert the current index value into a y position, and if it is within
					// the bounds of the rectangle, draw another horizontal line.
					GL.Vertex3(0, i * 10, 0);
					GL.Vertex3(layoutRectangle.width, i * 10, 0);
				}
			}

			// End lines drawing.
			GL.End();

			// Pop the current matrix for rendering, and end the drawing clip.
			GL.PopMatrix();
			GUI.EndClip();
		}

		// End our horizontal 
		GUILayout.EndHorizontal();
	}
	void DrawToolBar()
	{
		GUILayout.BeginHorizontal(EditorStyles.toolbar);
		if (viewNetworkTypes)
		{
			if (GUILayout.Button("Hide", EditorStyles.toolbarButton, GUILayout.Width(150)))
			{
				viewNetworkTypes = false;
			}
			if (GUILayout.Button("Refresh", EditorStyles.toolbarButton, GUILayout.Width(150)))
			{
				NetworkType.LoadList();
			}
		}
		else
		{
			if (GUILayout.Button("Open", EditorStyles.toolbarButton, GUILayout.Width(300)))
			{
				viewNetworkTypes = true;
				NetworkType.LoadList();
			}
		}


		if (GUILayout.Button("New", EditorStyles.toolbarButton))
		{
			if (loadedType != null) loadedType.Save();
			loadedType = new NetworkType();
		}
		EditorGUI.BeginDisabledGroup(loadedType == null);
		if (GUILayout.Button("Duplicate", EditorStyles.toolbarButton))
		{
			loadedType = new NetworkType(loadedType);
		}
		if (!TrainingController.training)
		{
			if (GUILayout.Button("Train", EditorStyles.toolbarButton))
			{
				TrainingController.Start(loadedType);
			}
		}
		else
		{
			if (GUILayout.Button("Stop", EditorStyles.toolbarButton))
			{
				TrainingController.Stop();
			}
		}

		EditorGUI.EndDisabledGroup();
		GUILayout.EndHorizontal();
	}
	bool showGenome = false;

	int selectedGeneration = 0;
	Vector2 scrollPos;
	void DrawGenomeList()
	{
		if (loadedType == null) return;
		GUILayout.BeginHorizontal();
		if (GUILayout.Button("-1", EditorStyles.toolbarButton, GUILayout.Width(30)))
		{
			selectedGeneration--;
		}

		selectedGeneration = EditorGUILayout.DelayedIntField(selectedGeneration, GUILayout.Width(30));
		if (selectedGeneration > loadedType.generations)
		{
			selectedGeneration = loadedType.generations;
		}
		if (selectedGeneration < 0)
		{
			selectedGeneration = 0;
		}


		if (GUILayout.Button("+1", EditorStyles.toolbarButton, GUILayout.Width(30)))
		{
			selectedGeneration++;
		}
		GUILayout.EndHorizontal();

		GUILayout.BeginVertical(EditorStyles.helpBox, GUILayout.MinHeight(50));
		if (loadedType.generations > 0)
		{
			scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Height(100));
			for (int i = 0; i < loadedType.population; i++)
			{
				GUILayout.BeginHorizontal(EditorStyles.helpBox);
				GUILayout.Label(i.ToString() + ":");
				GUILayout.Label("Fitness: " + loadedType.generation[selectedGeneration][i].fitness.ToString());

				GUILayout.EndHorizontal();
			}
			EditorGUILayout.EndScrollView();
		}
		else
		{
			GUILayout.Label("Start training the network to view the population");
		}
		GUILayout.EndVertical();
	}
	void DrawGenome()
	{
		showGenome = EditorGUILayout.Foldout(showGenome, "Genome Visual", true);
		if (!showGenome) return;
		if (loadedGenome == null) return;

		// Begin to draw a horizontal layout, using the helpBox EditorStyle
		GUILayout.BeginVertical(EditorStyles.helpBox);



		GUILayout.EndVertical();
	}
}