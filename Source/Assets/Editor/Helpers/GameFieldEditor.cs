using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(GameField))]
[CanEditMultipleObjects]
public class GameFieldEditor : Editor
{
	public GameField gameField;
	public override void OnInspectorGUI()
    {
    	base.OnInspectorGUI();
		if (GUILayout.Button("My editor button"))
		{
			
		}
    }
}

