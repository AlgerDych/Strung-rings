using UnityEngine;
using System.Collections.Generic;

public class Fish : MonoBehaviour {
	
	public enum FishState
	{
		Normal,
		Atacked,
		Paused,
		Wormed,
		Shoked,
		None
	}
	public enum FishDirection
	{
		Forward,
		Back,
		Up,
		None
	}
	#region Unity variables
	public float speed;
	public float targetSize;
	public Transform forwardPoint;
	public Transform leftBorder;
	public Transform rightBorder;
	public List<Transform> movementPoints = new List<Transform>();
	#endregion
	
	#region VARIABLES
	private float _t;
	private Vector3 _targetPosition;
	private Vector3 _startPosition;

	#endregion
	
	#region PROPERTIES
	protected FishState _state;
	public FishState State
	{
		get { return _state; }
		set
		{
			if(_state != value)
			{
				FishState temp = _state;
				_state = value;
				OnStateChanged(temp,value);
			}
		}
	}	
	protected FishDirection _direction;
	public FishDirection Direction
	{
		get { return _direction; }
		set
		{
			if(_direction != value)
			{
				FishDirection temp = _direction;
				_direction = value;
				OnDirectionChanged(temp,value);
			}
		}
	}	
	#endregion
	
	#region EVENTS
	public System.Action<FishState,FishState> StateChanged;
	protected void OnStateChanged(FishState oldValue, FishState newValue)
	{
		if(StateChanged != null)
			StateChanged(oldValue,newValue);
	}
	
	public System.Action<FishDirection,FishDirection> DirectionChanged;
	protected void OnDirectionChanged(FishDirection oldValue, FishDirection newValue)
	{
		if(DirectionChanged != null)
			DirectionChanged(oldValue,newValue);
	}	
	#endregion
	// Use this for initialization
	void Start () 
	{
		_startPosition = new Vector3(rightBorder.position.x, transform.position.y, rightBorder.position.z);
		_targetPosition = new Vector3(leftBorder.position.x, transform.position.y, leftBorder.position.z);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(State == FishState.Normal)
		{
			if(_t <= 1.0f)
			{
				_t += 1 / (500 - speed);
				transform.position = Vector3.Lerp(_startPosition, _targetPosition, _t);
			}
			else
			{
				if(Direction == FishDirection.Back)
					Direction = FishDirection.Forward;
				else if (Direction == FishDirection.Forward)
					Direction = FishDirection.Back;
				else if (Direction == FishDirection.Up)
				{
					Direction = FishDirection.None;
					State = FishState.Wormed;
				}
				_t = 0;
			}
		}
	}
	
	public void Init(FishState state, float speed, Vector3 leftPoint, Vector3 rigthPoint, Vector3 startPoint, FishDirection direction)
	{
		this.speed = speed;
		//_startPosition = startPoint;
		//_targetPosition = endPoint;
		State = state;
		Direction = direction;
	}
	
	void OnDrawGizmos()
	{
		//Gizmos.color = Color.red;
		//Gizmos.DrawWireSphere(forwardPoint.position, targetSize);
		
		if(movementPoints.Count < 1)
		{
			Debug.Log("Not point");
			return;
		}
		Vector3 lastPoint = movementPoints[0].transform.position;
		Gizmos.color = Color.green;
		for(int i = 1; i < movementPoints.Count; i++)
		{
			Gizmos.DrawIcon(lastPoint, "Point " + i.ToString());
			Gizmos.DrawLine(lastPoint, movementPoints[i].transform.position);
			lastPoint = movementPoints[i].transform.position;
		}
	}
}
