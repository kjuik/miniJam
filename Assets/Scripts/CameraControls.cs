using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour {
	
	public float camSpeed = 10f;
	
	void Update () {
		
		bool left = Input.GetKey(KeyCode.Alpha2);
		bool right = Input.GetKey(KeyCode.Alpha1);
		
		float turn = 0f;
		if (left)
			turn -= camSpeed;
		if (right)
			turn += camSpeed;
		
		transform.RotateAround(
			GameObject.Find("Player").transform.position,
			Vector3.up,
			Time.deltaTime * turn
		);
	}
}
