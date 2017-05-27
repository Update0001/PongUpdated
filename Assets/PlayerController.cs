using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public GameObject Player1,Player2;
	public Transform orbit;
	public float speed = 4;
	private Vector3 LeftAxis = new Vector3(0, 0, 1);
	private Vector3 RightAxis = new Vector3(0, 0, -1);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale == 1f) {
			if (Input.GetKey (KeyCode.UpArrow)) {
				TurnRight01 ();
			}
			if (Input.GetKey (KeyCode.DownArrow)) {
				TurnLeft01 ();
			}

			if (Input.GetKey (KeyCode.W)) {
				TurnRight02 ();
			}
			if (Input.GetKey (KeyCode.S)) {
				TurnLeft02 ();
			}
		}
	}
	void TurnLeft01(){
		Player1.transform.RotateAround(orbit.position, RightAxis, speed); 
	}
	void TurnRight01(){
		Player1.transform.RotateAround(orbit.position, LeftAxis, speed); 
	}
	void TurnLeft02(){
		Player2.transform.RotateAround(orbit.position, RightAxis, speed); 
	}
	void TurnRight02(){
		Player2.transform.RotateAround(orbit.position, LeftAxis, speed); 
	}

}
