using UnityEngine;
using System.Collections.Generic;

public class Stairway : MonoBehaviour {
	
	public Step stepPrefab;
	public int stepsAmount = 100;
	public int xRange = 20;
	
	public List<Step> steps = new List<Step>();
	
	// Use this for initialization
	void Start () {
		for (int i=0; i<stepsAmount; i++){
			
			Step step = (Step) Instantiate(stepPrefab);
			
			step.transform.position = new Vector3(
				
				(i == 0) ? 0	
				: Random.Range(-xRange,xRange),
				i * step.transform.lossyScale.y,
				i * step.transform.lossyScale.z
				);
			step.transform.parent = transform;
			
			steps.Add(step);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
