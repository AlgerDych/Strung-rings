using UnityEngine;
using System.Collections;

public class Shell : MonoBehaviour {
	
	public float moduleForce;
	public string shellLayer;
	
	public event System.Action<Shell,float> ShellClicked;
	protected void OnShellClicked()
	{
		if(ShellClicked != null)
			ShellClicked(this,moduleForce);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.mainCamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer(shellLayer)))
			{
				if(hit.transform == transform)
					OnShellClicked();
			}
		}
	}
}
