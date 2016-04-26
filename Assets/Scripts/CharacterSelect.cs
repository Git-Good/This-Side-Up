﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using Image = UnityEngine.UI.Image;

public class CharacterSelect : MonoBehaviour {

	public GameObject[] CatList;
    public GameObject selectButton;
	public List<Player> Players = new List<Player> ();
	private int catNum;
	private PlayerList playerList;
	static int highScore;

    public GameObject playerReq;

    public Transform PlayerLocation;

	public AudioClip menuClick;
	AudioSource menuC;

	void Awake(){
		menuC = GetComponent<AudioSource> ();
	}

	// Use this for initialization
	void Start () {
		// Don't let screen turn off
		Screen.sleepTimeout = SleepTimeout.NeverSleep;

        playerList = GameObject.FindGameObjectWithTag ("Player List").GetComponent<PlayerList> ();
		highScore = PlayerPrefs.GetInt ("HighScore");

		Players.Clear ();
		for (int i = 0; i < CatList.Length; i++) {
			Players.Add (playerList.players[i]);
		}
			
		if (PlayerLocation == null) {
			PlayerLocation = transform;
		}

		foreach (GameObject cat in CatList) {
			cat.transform.position = PlayerLocation.position;
			cat.SetActive (false);
		}

		// Show selected cat
		ShowCat (PlayerPrefs.GetInt("PlayerNum"));
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene ("This Side Up");
		}
	}

	public void ShowNext(){
		menuC.PlayOneShot (menuClick);
		ShowCat (catNum + 1);
	}

	public void ShowPrevious(){
		menuC.PlayOneShot (menuClick);
		ShowCat (catNum - 1);
	}

	void ShowCat(int num){
        if (num >= Players.Count) {
			num = 0;
		}
		else if (num < 0){
			num = Players.Count-1;
		}

		CatList [catNum].SetActive (false);
		catNum = num;
		CatList [catNum].SetActive (true);

        // Doge
        // Need 30 score to play as Doge
        // Should write code that detects if there is a requirement and do this automatically
		if (catNum == 5 && highScore < 30) {
            // Set requirement notification on
            playerReq.SetActive(true);
            SpriteRenderer dogeSprite = CatList[5].GetComponent<SpriteRenderer>();
            Image dogeName = CatList[5].GetComponentInChildren<Image>();
            dogeSprite.color = new Color32(61, 61, 61, 255);
            dogeName.color = new Color32(61, 61, 61, 255);
            selectButton.SetActive(false);
        }
        else
        {
            // Set requirement notification off
            playerReq.SetActive(false);
            selectButton.SetActive(true);
        }
    }

	public void SelectCat(){
        menuC.PlayOneShot(menuClick);
		if (catNum == 5 && highScore < 30) {
			//do nothing
		}
		else {
            menuC.PlayOneShot(menuClick);
            PlayerPrefs.SetString("Player", Players[catNum].catName);
			PlayerPrefs.SetInt("PlayerNum", catNum);
			StartCoroutine(LoadCat());
		}
  	}

	IEnumerator LoadCat(){
		yield return new WaitForSeconds (menuClick.length-0.4f);
		SceneManager.LoadScene ("This Side Up");
	}
}
