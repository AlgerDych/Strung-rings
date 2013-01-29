using UnityEngine;
using System.Collections.Generic;
using System;

public class Ring : MonoBehaviour 
{
	public enum RingState
	{
		Normal,
		Fished,
		Crabed,
		Strung,
		Unknown
	}
	
	#region PROPERTIES
	public List<GameObject> colliders;
	protected float _damageLevel = -1.0f;
	public float DamageLevel
	{
		get { return _damageLevel; }
		set
		{
			if(_damageLevel != value)
			{
				float temp = _damageLevel;
				_damageLevel = value;
				OnDamageLevelChanged(temp,_damageLevel);
			}
		}
	}
	public float score;
	protected Color _ringColor;
	public Color RingColor
	{
		get { return _ringColor; }
		set
		{
			if(_ringColor !=  value)
			{
				_ringColor = value;
			}
		}
	}	
	protected RingState _state;
	public RingState State
	{
		get { return _state; }
		set
		{
			if(_state != value)
			{
				RingState temp = _state;
				_state = value;
				OnStateChanged(temp, _state);
			}
		}
	}
	private int _numberTexture = -1;
	public int countTextures = 10;
	#endregion
	
	#region EVENTS
	public Action<float,float> DamageLevelChanged;
	protected void OnDamageLevelChanged(float oldValue, float newValue)
	{
		if(DamageLevelChanged != null)
			DamageLevelChanged(oldValue,newValue);
		DamageLevelChange();
	}
	public Action<RingState,RingState> StateChanged;
	protected void OnStateChanged(RingState oldValue, RingState newValue)
	{
		if(StateChanged != null)
			StateChanged(oldValue,newValue);	
		StateChange();
	}
	public static Action<Ring, Collision> CollisionEnter;
	protected void OnCollision(Ring sender,Collision collision)
	{
		if(CollisionEnter != null)
			CollisionEnter(sender,collision);
	}
	#endregion

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision collision)
	{
		OnCollision(this, collision);
	}
	
	public void AddForce(Vector3 force)
	{
		if(State == RingState.Normal)
		{
			rigidbody.AddForce(force,ForceMode.Impulse);
		}
	}
	
	protected void StateChange()
	{
		if(State == RingState.Strung)
		{
			
		}
	}
	
	protected void DamageLevelChange()
	{
		int n = (int)DamageLevel / countTextures;
		if(n != _numberTexture)
		{
			_numberTexture = n;
			gameObject.renderer.material.mainTexture = (Texture)Resources.Load("Ring/Textures/Damage" + _numberTexture.ToString(), typeof(Texture));
		}
	}
	
	public void Init(Color color, Vector3 position, float initialDamage)
	{
		RingColor = color;
		gameObject.transform.position = position;
		DamageLevel = initialDamage;
		State = RingState.Normal;
	}
	
}
