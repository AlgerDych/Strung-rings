using UnityEngine;
using System.Collections;

public class Crab : MonoBehaviour {
	
	
	
	public enum CrabState
	{
		Normal,
		Atacked,
		Paused,
		None
	}
	public enum Direction
	{
		Left,
		Right
	}
	
	protected CrabState _state;
	public CrabState State
	{
		get { return _state; }
		set
		{
			if(_state != value)
			{
				CrabState oldValue = _state;
				_state = value;
			}			
		}			
	}
	protected Direction _direction;
	public Direction CrabDirection
	{
		get { return _direction; }
		set
		{
			if(_direction != value)
			{
				Direction oldValue = _direction;
				_direction = value;
			}			
		}			
	}
	public float radius;
	public Vector3 leftBorderPoint;
	public Vector3 rightBorderPoint;
	public float speed;
	private float _time;
	private Vector3 _targetPoint;
	public float LegthPath
	{
		get 
		{ 
			return Vector3.Distance(leftBorderPoint,rightBorderPoint);
		}
	}
	
	// Use this for initialization
	void Start () {
		transform.localPosition = leftBorderPoint;
		_targetPoint = rightBorderPoint;
	}
	 
	// Update is called once per frame
	void Update () 
	{
		if(_time < LegthPath / speed)
		{
			_time += Time.deltaTime;
			transform.localPosition = Vector3.Lerp(transform.position, _targetPoint, _time * speed / LegthPath);
			
		}
	
	}
	
	void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(transform.position,new Vector3(radius,radius,0));
	}
}
