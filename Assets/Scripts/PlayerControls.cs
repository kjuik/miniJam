using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {
	
	public float playerSpeed = 0.3f;
	
	public Camera cam;
	public Stairway stairway;
	
	public int currentStep = 0;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 rightAxis = cam.transform.right;
		Vector3 forwardAxis = cam.transform.forward;
		
		if (Input.GetAxis("Horizontal") != 0f){
			transform.Translate(rightAxis * Input.GetAxis("Horizontal") * playerSpeed);
		}
		if (Input.GetAxis("Vertical") != 0f){
			transform.Translate(forwardAxis * Input.GetAxis("Vertical") * playerSpeed);
		}
		
		if (Input.GetKeyDown(KeyCode.Space)){
			
			Vector3 playerPos = cam.WorldToScreenPoint(transform.position);
			
			Vector3 nextStepLeft3d = stairway.steps[currentStep+1].left();
			Vector3 nextStepRight3d = stairway.steps[currentStep+1].right();
			
			Vector3 nextStepLeft2d = cam.WorldToScreenPoint(nextStepLeft3d);
			Vector3 nextStepRight2d = cam.WorldToScreenPoint(nextStepRight3d);
			
			if (
				nextStepLeft2d.x < playerPos.x
				&&
				playerPos.x < nextStepRight2d.x
				)
			{
				float positionOnStep = 
					(playerPos.x - nextStepLeft2d.x) /
					(nextStepRight2d.x - nextStepLeft2d.x);			
				Vector3 targetPos = 
					nextStepLeft3d + 
					(positionOnStep) * (nextStepRight3d - nextStepLeft3d)
						
					+ Vector3.up * transform.localScale.y	
						;

				currentStep++;
				
			iTween.MoveTo(gameObject,iTween.Hash(
				"x",targetPos.x,
				"y",targetPos.y,
				"z",targetPos.z,
				"time",0.2f,
				"easeType", "linear"));	
			}
			else {
				cam.transform.parent = null;
				animation.Play();	
				
			}

		}
	}
}
