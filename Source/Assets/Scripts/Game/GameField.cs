using UnityEngine;
using System.Collections;


public class GameField : MonoBehaviour 
{	
	public const float DEFAULT_WIDTH = 960;
	public const float DEFAULT_HEIGTH = 480;
	
	public GameObject leftBorder;
	public GameObject rightBorder;
	public GameObject topBorder;
	public GameObject bottomBorder;
	public GameObject frontBorder;
	public GameObject backBorder;
	

	
	public Camera viewCamera;
	
	public float distance = 10.0f;

	
	// Use this for initialization
	void Start () 
	{
		Init (Screen.width, Screen.height);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	private void Init(float width, float heigth)
	{
		Vector3 size = new Vector3(DEFAULT_WIDTH / DEFAULT_HEIGTH , 1 , 10);
		Ray ray = viewCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
		Vector3 position = ray.GetPoint(distance);
		
		ray = viewCamera.ViewportPointToRay(new Vector3(0, 0, 0));
		Vector3 point00 = ray.GetPoint(distance / Mathf.Cos(Mathf.PI * viewCamera.fieldOfView / 360 ));
		
		ray = viewCamera.ViewportPointToRay(new Vector3(1, 1, 0));
		Vector3 point11 = ray.GetPoint(distance / Mathf.Cos(Mathf.PI * viewCamera.fieldOfView / 360 ));
		
		float koeffX = (point00 - point11).x / size.x;
		float koeffY = (point00 - point11).y / size.y;
		
		size.x *= koeffX >= koeffY ? koeffX : koeffY;
		size.y *= koeffX < koeffY ? koeffY : koeffX;
		
				
		frontBorder.transform.position = new Vector3(position.x,position.y,position.z - size.z / 2);
		frontBorder.transform.localScale = 0.1f * new Vector3(size.x, 10f, size.y);
		frontBorder.transform.rotation = Quaternion.Euler(90,0,0);
		
		backBorder.transform.position = new Vector3(position.x,position.y,position.z + size.z / 2);
		backBorder.transform.localScale = 0.1f *  new Vector3(size.x, 10f, size.y);
		backBorder.transform.rotation = Quaternion.Euler(90,180,0);
		
		leftBorder.transform.position = new Vector3(position.x - size.x / 2, position.y ,position.z);
		leftBorder.transform.localScale = 0.1f *  new Vector3(size.y, 10f, size.z);
		leftBorder.transform.rotation = Quaternion.Euler(0,180,90);
		
		rightBorder.transform.position = new Vector3(position.x + size.x / 2,position.y ,position.z);
		rightBorder.transform.localScale = 0.1f *  new Vector3(size.y, 10f, size.z);
		rightBorder.transform.rotation = Quaternion.Euler(0,0,90);
		
		topBorder.transform.position = new Vector3(position.x,position.y - size.y / 2 ,position.z);
		topBorder.transform.localScale = 0.1f *  new Vector3(size.x, 10f, size.z);
		topBorder.transform.rotation = Quaternion.Euler(180,0,0);
		
		bottomBorder.transform.position = new Vector3(position.x,position.y + size.y / 2 ,position.z);
		bottomBorder.transform.localScale = 0.1f *  new Vector3(size.x, 10f, size.z);
		bottomBorder.transform.rotation = Quaternion.Euler(0,0,0);
	}
	
	void OnDrawGizmos()
	{
	
	}
}

