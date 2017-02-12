//www.2hStudio.eu
//12/02/2017
//17:45
//Whitesgate - Frontroom

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Spawner : MonoBehaviour {

	public GameObject platform;
	public GameObject diamond;

	Vector3 lastPos;

	float size;

	public bool game_Over;

	// Use this for initialization
	void Start () {
		lastPos = platform.transform.position;
		//Give platform size
		size = platform.transform.localScale.x;

		for (int i = 0; i < 20; i++) {
			Spawn_Platforms ();
		}

		//Call function after 2 seconds and then repeat the call every 0.2 seconds going forward
		InvokeRepeating ("Spawn_Platforms", 2.0f, 0.2f);

	}
	
	// Update is called once per frame
	void Update () {
		//Return jumos out of the function and does no more
		if (game_Over) {
			CancelInvoke ("Spawn_Platforms");
		}
	}

	void Spawn_Platforms(){
		int rand = Random.Range (0, 6);

		if (rand < 3) {
			Spawn_X ();
		} else if (rand >= 3) {
			Spawn_Z ();
		}
	}

	void Spawn_X(){
		Vector3 pos = lastPos;
		pos.x += size;
		//Set to new position for next spawn calculation
		lastPos = pos;
		//No rotation
		Instantiate (platform, pos, Quaternion.identity);

		int rand = Random.Range (0, 4);
		if (rand < 1) {
 			Instantiate (diamond, new Vector3(pos.x, pos.y + 1.0f, pos.z), diamond.transform.rotation);
		}
	}

	void Spawn_Z(){
		Vector3 pos = lastPos;
		pos.z += size;
		//Set to new position for next spawn calculation
		lastPos = pos;
		//No rotation
		Instantiate (platform, pos, Quaternion.identity);

		int rand = Random.Range (0, 4);
		if (rand < 1) {
			Instantiate (diamond, new Vector3(pos.x, pos.y + 1.0f, pos.z), diamond.transform.rotation);
		}
	}
}
