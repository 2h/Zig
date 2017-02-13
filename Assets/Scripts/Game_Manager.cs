//www.2hStudio.eu
//13/02/2017
//18:37
//Whitesgate - Frontroom

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour {

	public static Game_Manager instance;

	public bool game_Over;

	void Awake(){
		if (instance == null) {
			instance = this;
		}
	}

	// Use this for initialization
	void Start () {
		game_Over = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GameStart(){
		UI_Manager.instance.GameStart ();
		Score_Manager.instance.start_Score ();
	}

	public void GameOver(){
		UI_Manager.instance.GameOver ();
		Score_Manager.instance.StopScore ();
	}
}
