//www.2hStudio.eu
//12/02/2017
//12:33
//Whitesgate - Frontroom
//GAME STARTS HERE

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Controller : MonoBehaviour {

	public GameObject particle;

	[SerializeField]
	private float speed;
	private float speed_drop = -25.0f;

	bool started;
	bool game_Over;

	Rigidbody rb;

	void Awake(){
		rb = GetComponent<Rigidbody> ();
	}

	// Use this for initialization
	void Start () {
		started = false;
		game_Over = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (!started) {
			if (Input.GetMouseButton (0)) {
				rb.velocity = new Vector3 (speed, 0, 0);
				started = true;

				////////////////////
				////////////////////
				/// GAME STARTS HERE
				////////////////////
	
				Game_Manager.instance.GameStart ();

			}
		}


		//Checking to see if ball has left the platform (downward vector test)
		//Returns a true/false based on collision
		//When no collision, Game Over is now true as we are no longer on the platform
		Debug.DrawRay (transform.position, Vector3.down, Color.red);

		if(!Physics.Raycast (transform.position, Vector3.down, 1.0f)){
			game_Over = true;
			//When Gameover occurs, ball should drop
			rb.velocity = new Vector3 (0, speed_drop, 0);

			//Freeze the camera
			Camera.main.GetComponent<Camera_Follow>().game_Over = true;

			//////////////////
			//////////////////
			/// GAME ENDS HERE
			//////////////////

			Game_Manager.instance.GameOver ();
		}

		if (Input.GetMouseButtonDown (0) && !game_Over) {
			Switch_Direction ();
		}
	}

	void Switch_Direction(){
		//Ball moving in the z direcion and so on
		if (rb.velocity.z > 0) {
			rb.velocity = new Vector3 (speed, 0, 0);
		} else if (rb.velocity.x > 0) {
			rb.velocity = new Vector3 (0, 0, speed);
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Diamond") {
			GameObject part = Instantiate (particle, other.gameObject.transform.position, Quaternion.identity) as GameObject;
			Destroy (part, 1.0f);

			Destroy (other.gameObject);

		}
	}
}
