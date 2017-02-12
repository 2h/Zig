//www.2hStudio.eu
//12/02/2017
//17:09
//Whitesgate - Frontroom

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Checker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Ball") {

			//Calle FallDown after 0.5f seconds
			Invoke("FallDown", 0.5f);
		}
	}

	void FallDown(){
		//Gravity will now cause platforms to fall.
		//isKinematic is set to false to allow grabity to act.
		//This is only done on tthe affected platform to stop other platforms being disturbed by
		//Physics.
		GetComponentInParent<Rigidbody> ().useGravity = true;
		GetComponentInParent<Rigidbody> ().isKinematic = false;
		//Destroy parent
		Destroy (transform.parent.gameObject, 2.0f);
	}
}
