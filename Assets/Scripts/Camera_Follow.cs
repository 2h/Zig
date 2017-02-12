//www.2hStudio.eu
//12/02/2017
//15:03
//Whitesgate - Frontroom

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour {

	public GameObject ball;
	//Distance between camera and ball
	Vector3 offset;

	public float lerp_Rate;

	public bool game_Over;

	// Use this for initialization
	void Start () {
		//ball - camera position = distance
		offset = ball.transform.position - transform.position;
		game_Over = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(!game_Over){
			Follow();
		}
	}

	void Follow(){
		Vector3 pos = transform.position;
		//Position to locate camera
		Vector3 target_pos = ball.transform.position - offset;
		pos = Vector3.Lerp (pos, target_pos, lerp_Rate * Time.deltaTime);
		transform.position = pos;
	}

}
