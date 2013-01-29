using UnityEngine;
using System.Collections.Generic;
using System;

public class GameController : MonoBehaviour {
	
	public Shell leftShell;
	public Shell rightShell;
	
	public List<Ring> rings;
	
	public Stand leftStand;
	public Stand rightStand;
	
	public List<Fish> fish;
	
	public List<Crab> crabs;
	
	public List<GameObject> _strungGameObjects;
	
	
	// Use this for initialization
	void Start () 
	{
		leftShell.ShellClicked += ShellClicked;
		rightShell.ShellClicked += ShellClicked;
		Ring.CollisionEnter += RingCollisionEnter;
		_strungGameObjects = new List<GameObject>();
		_strungGameObjects.Add(leftStand.plane);
		_strungGameObjects.Add(rightStand.plane);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Physics.gravity = Input.gyro.gravity;
		//Debug.Log(Input.gyro.attitude);
		//Debug.Log(Physics.gravity);
	
	}
	
	
	void OnDestroy()
	{
		leftShell.ShellClicked -= ShellClicked;
		rightShell.ShellClicked -= ShellClicked;
		Ring.CollisionEnter -= RingCollisionEnter;
	}
	
	private void RingCollisionEnter(Ring sender, Collision collision)
	{
		//Debug.Log("Collision : " + collision.gameObject);
		if(_strungGameObjects.Contains(collision.gameObject))
		{
			Debug.Log("Collision : " + collision.gameObject + " Sender : " + sender.State);
			//Bounds bounds = collision.gameObject == leftStand.plane ? leftStand.capsule.collider.bounds : rightStand.capsule.collider.bounds;
			if((leftStand.capsule.collider.bounds.Contains(sender.transform.position)  || rightStand.capsule.collider.bounds.Contains(sender.transform.position))&& sender.State == Ring.RingState.Normal)
			{
				sender.State = Ring.RingState.Strung;
				//_strungGameObjects.AddRange(sender.colliders.ToArray());
				_strungGameObjects.Add(sender.gameObject);
			}
		}
	}
	
	private void ShellClicked(Shell sender,float moduleForce)
	{
		if(sender == null)
			return;
		foreach(var ring in rings)
		{
			Vector3 direction = (ring.transform.position - sender.transform.position).normalized + 0.1f * Vector3.up;
			ring.AddForce(direction.normalized * moduleForce);			
		}
	}
}
