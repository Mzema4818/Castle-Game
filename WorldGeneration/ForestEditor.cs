using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(ForestGenerator))]
public class ForestEditor : Editor
{

	public override void OnInspectorGUI()
	{
		ForestGenerator mapGen = (ForestGenerator)target;

		if (DrawDefaultInspector())
		{
			if (mapGen.autoUpdate)
			{
				mapGen.GenerateMap();
			}
		}

		if (GUILayout.Button("Generate"))
		{
			mapGen.GenerateMap();
		}
	}
}