using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(Fish))]
[CanEditMultipleObjects]
public class FishEditor : Editor 
{
	private Vector2 _scrollPosition;		
	
	public override void OnInspectorGUI()
	{
		Fish fish = (Fish)target;
		base.OnInspectorGUI();
		if (GUILayout.Button("Add new point"))
		{
			GameObject point = new GameObject("Point " + fish.movementPoints.Count.ToString());
			point.transform.position = fish.transform.position;			
			point.transform.parent = fish.transform;
			Debug.Log(point.transform.position);
			fish.movementPoints.Add(point.transform);
		}
		
		_scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition, GUILayout.Height(200));
		for(int i = 0; i < fish.movementPoints.Count; i ++)
		{
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.PrefixLabel("Point " + i.ToString());			
			fish.movementPoints[i] = (Transform)EditorGUILayout.ObjectField(fish.movementPoints[i], typeof(Transform));			
			if(GUILayout.Button("X"))
			{
				GameObject.DestroyImmediate(fish.movementPoints[i].gameObject);
				fish.movementPoints.RemoveAt(i);
			}
			EditorGUILayout.EndHorizontal();
		}
		EditorGUILayout.EndScrollView();
		
	}
}
