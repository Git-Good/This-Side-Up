﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {

    public GameObject GameTitle;
    public GameObject UIButtons;
	public GameObject ScoreText;
	public GameObject HighScoreText;
	public GameObject instructions;
	public bool userInput = false;

	public AudioClip menuClick;
	AudioSource menuC;

    private bool tapped = false;
	private bool lose = false;
	// static so that reloading the scene will not change the variable
	private static bool restart = false;

	void Awake(){
		menuC = GetComponent<AudioSource> ();
	}

	// Use this for initialization
	void Start () {
		if (restart != true) {
			instructions.SetActive (false);
			GameTitle.SetActive (true);
			UIButtons.SetActive (true);
			ScoreText.SetActive (false);
			HighScoreText.SetActive (false);
			userInput = false;
		} else {
			instructions.SetActive (true);
			GameTitle.SetActive(false);
			UIButtons.SetActive(false);
			ScoreText.SetActive(true);
			userInput = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (tapped != false && lose != true)
        {
            GameTitle.SetActive(false);
            UIButtons.SetActive(false);
			ScoreText.SetActive(true);
			userInput = true;
        }
	}

	public void RemoveInstructions(){
		instructions.SetActive (false);
	}

	void RestartGame(){
		SceneManager.LoadScene ("This Side Up");
		restart = true;
	}

	public void ShowHighScore(){
		UIButtons.SetActive(true);
		HighScoreText.SetActive(true);
		GameObject hscoreText = GameObject.FindWithTag ("HighScoreText");
		hscoreText.SendMessage ("ShowHighScore");
	}

	public void Lose(){
		lose = true;
		restart = true;
		ShowHighScore ();
	}

    public void Tapped()
    {
		menuC.PlayOneShot (menuClick);
		StartCoroutine (MenuSound ());
    }

	public void CharSelect(){
		menuC.PlayOneShot (menuClick);
		StartCoroutine (LoadCatSelect ());
	}

	IEnumerator MenuSound(){
		yield return new WaitForSeconds (menuClick.length-0.4f);
		instructions.SetActive (true);
		tapped = true;
		if (lose == true) {
			RestartGame ();
		}
	}

	IEnumerator LoadCatSelect (){
		yield return new WaitForSeconds (menuClick.length-0.4f);
		SceneManager.LoadScene ("Character Select");
	}
}