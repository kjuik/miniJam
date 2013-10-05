using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {
	
	public float playerSpeed = 0.3f;
	public Camera cam;
	public Stairway stairway;
	public int currentStep = 0;
	public float up_distance = 500.0f;
	public float forward_distance = 500.0f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//Determining the screen direction
		Vector3 rightAxis = cam.transform.right;
		Vector3 forwardAxis = cam.transform.forward;
		
		//Movement of player on the step		
		if (Input.GetAxis("Horizontal") != 0f){
			transform.Translate(rightAxis * Input.GetAxis("Horizontal") * playerSpeed);}
		if (Input.GetAxis("Vertical") != 0f){
			transform.Translate(forwardAxis * Input.GetAxis("Vertical") * playerSpeed);}
		
		//Movement of player to a different step
		if (Input.GetKeyDown(KeyCode.Space)){			
			Vector3 playerPos = cam.WorldToScreenPoint(transform.position);
			
			Vector3 nextStepLeft3d = stairway.steps[currentStep+1].left();
			Vector3 nextStepRight3d = stairway.steps[currentStep+1].right();
			
			Vector3 nextStepLeft2d = cam.WorldToScreenPoint(nextStepLeft3d);
			Vector3 nextStepRight2d = cam.WorldToScreenPoint(nextStepRight3d);
			
			//Checking if step is valid
			if (
				nextStepLeft2d.x < playerPos.x
				&&
				playerPos.x < nextStepRight2d.x
				)
			{ //Calculation for the desired movement
				float positionOnStep = 
					(playerPos.x - nextStepLeft2d.x) /
					(nextStepRight2d.x - nextStepLeft2d.x);			
				Vector3 targetPos = 
					nextStepLeft3d + 
					(positionOnStep) * (nextStepRight3d - nextStepLeft3d)
						
					+ Vector3.up * transform.localScale.y	
						;

				currentStep++;
			//Movement of player
			iTween.MoveTo(gameObject,iTween.Hash(
				"x",targetPos.x,
				"y",targetPos.y,
				"z",targetPos.z,
				"time",0.2f,
				"easeType", "linear"));	
			}
			//If not valid
			else {
				//Detach the camera
				cam.transform.parent = null;
				
				//Add a force in forward and upward direction, to simulate a jump
				rigidbody.AddForce(forwardAxis * forward_distance);
				rigidbody.AddForce(0, up_distance, 0);
				
				//MOVE NEXT SCREEN
			}

		}
	}
}
