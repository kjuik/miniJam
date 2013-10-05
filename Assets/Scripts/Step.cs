using UnityEngine;
using System.Collections;

public class Step : MonoBehaviour {
	
	public GameObject Left;
	public GameObject Right;
	
	public Vector3 left(){
		return Left.transform.position;
	}
	
	public Vector3 right(){
		return Right.transform.position;
	}
}
