using UnityEngine;
using System.Collections;

public class PressStart : MonoBehaviour {
	
	public GUIText oStart;
	public GUIText oContinue;
	
	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}
	
	// Loads the level when clicking the "PRESS START TO PLAY" text.
	void OnMouseDown() 
	{
		//Loads up the level.
		//Application.LoadLevel();
		Debug.Log ("Start has been pressed!");
	}
}
