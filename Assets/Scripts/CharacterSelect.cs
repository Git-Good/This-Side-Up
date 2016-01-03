using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class CharacterSelect : MonoBehaviour {

	public GameObject[] CatList;
	public List<Player> Players = new List<Player> ();
	private int catNum;
	private PlayerList playerList;

	public Transform PlayerLocation;

	// Use this for initialization
	void Start () {
		// Don't let screen turn off
		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		playerList = GameObject.FindGameObjectWithTag ("Player List").GetComponent<PlayerList> ();
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

		// Show first cat
		ShowCat (0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene ("This Side Up");
		}
	}

	public void ShowNext(){
		ShowCat (catNum + 1);
	}

	public void ShowPrevious(){
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
	}

	public void SelectCat(){
		PlayerPrefs.SetString ("Player", Players[catNum].catName);
		//Debug.Log("Selected: " + PlayerPrefs.GetString("Player"));
		SceneManager.LoadScene ("This Side Up");
	}
}
