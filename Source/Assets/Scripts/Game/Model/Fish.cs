using UnityEngine;
using System.Collections;

public class Fish : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(gameObject.transform.position, Vector3.one);
	}
}
