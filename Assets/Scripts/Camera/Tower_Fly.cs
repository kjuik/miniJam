using UnityEngine;
using System.Collections;

public class Tower_Fly : MonoBehaviour {
	
	public Transform oTower;
	
	public float fMaxHeight = 15f;
	public float fMinHeight = 3f;
	
	public float fVelocity = 0.6f;
	
	private bool bRise = true;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (transform.position.y < fMinHeight)
		{
			bRise = true;
		}
		else if (transform.position.y > fMaxHeight)
		{
			bRise = false;
		}
		RaiseCamera(bRise);
	} 
	
	
	
	void RaiseCamera(bool bRise)
	{
		if(bRise == true)
		{
			transform.Translate(Vector3.up * Time.deltaTime * fVelocity);
			transform.RotateAround(oTower.position, (Vector3.up*10), 20*Time.deltaTime);
		}
		else if(bRise == false)
		{
			transform.Translate(-Vector3.up * Time.deltaTime * fVelocity);
			transform.RotateAround(oTower.position, (Vector3.up*10), 20*Time.deltaTime);
		}
	}
}
