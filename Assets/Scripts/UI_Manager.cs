//www.2hStudio.eu
//13/02/2017
//14:35
//Whitesgate - Frontroom

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour {

	//Singleton Pattern
	public static UI_Manager instance;

	public GameObject zig_Panel;
	public GameObject game_Over_Panel;
	public GameObject tap_Text;
	public Text score;
	public Text high_Score001;
	public Text high_Score002;

	void Awake(){
		//No instance created yet
		if (instance == null) {
			instance = this;
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GameStart(){
		tap_Text.SetActive (false);
		zig_Panel.GetComponent<Animator> ().Play ("Panel_Up");
	}

	public void GameOver(){
		game_Over_Panel.SetActive (true);
	}

	public void Reset(){
		SceneManager.LoadScene (0);
	}
}
