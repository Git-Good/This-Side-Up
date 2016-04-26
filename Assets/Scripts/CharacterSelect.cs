using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class CharacterSelect : MonoBehaviour {

	public GameObject[] CatList;
	public List<Player> Players = new List<Player> ();
	private int catNum;
	private PlayerList playerList;
	static int highScore;

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

		if (catNum == 5 && highScore < 30) {
			Vector3 pos = new Vector3(0f, 1f, 0f);
			Instantiate (Resources.Load ("Text/Cat Names/UnlockGO"), pos, Quaternion.identity);
			//SpriteRenderer dogeRenderer = CatList[5].GetComponent(SpriteRenderer);
			//dogeRenderer.color = new Color (61, 61, 61, 61);

			//Destroy (GameObject.FindWithTag ("UnlockReq"));
		}
	}

	public void SelectCat(){
        menuC.PlayOneShot(menuClick);
		if (catNum == 5 && highScore < 30) {
			//do nothing
		}
		else {
			Debug.Log (catNum);
			Debug.Log (highScore);
			PlayerPrefs.SetString("Player", Players[catNum].catName);
			PlayerPrefs.SetInt("PlayerNum", catNum);
			StartCoroutine(LoadCat());
		}
        //Debug.Log("Selected: " + PlayerPrefs.GetString("Player"));
  	}

	IEnumerator LoadCat(){
		yield return new WaitForSeconds (menuClick.length-0.4f);
		SceneManager.LoadScene ("This Side Up");
	}
}
