//www.2hStudio.eu
//13/02/2017
//18:24
//Whitesgate - Frontroom

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_Manager : MonoBehaviour {

	public static Score_Manager instance;

	public int score;
	public int high_Score;

	void Awake(){
		if (instance == null) {
			instance = this;
		}
	}

	// Use this for initialization
	void Start () {
		score = 0;
		//(key, value)
		PlayerPrefs.SetInt("score", score);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Increment_Score(){
		score++;
	}

	public void start_Score(){
		//Score increments based on time
		InvokeRepeating("Increment_Score", 0.1f, 0.5f);
	}

	public void StopScore(){
		CancelInvoke ("start_Score");
		PlayerPrefs.SetInt ("score", score);

		if (PlayerPrefs.HasKey ("highScore")) {
			
			if (score > PlayerPrefs.GetInt ("highScore")) {
				PlayerPrefs.SetInt ("highScore", score); 
			}

		} else {
			PlayerPrefs.SetInt ("highScore", score);
		}
	}

}
