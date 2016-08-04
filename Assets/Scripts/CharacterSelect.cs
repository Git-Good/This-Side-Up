using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using Image = UnityEngine.UI.Image;

public class CharacterSelect : MonoBehaviour {

	public GameObject[] CatList;
    public GameObject selectButton;
    public GameObject buyButton;
    public GameObject buyButton2;
    public List<Player> Players = new List<Player> ();
	private int catNum;
	private PlayerList playerList;
	static int highScore;

    public GameObject playerReq;
    public GameObject playerReq2;

    public Transform PlayerLocation;

	public AudioClip menuClick;
	AudioSource menuC;

    void Awake(){
		menuC = GetComponent<AudioSource> ();
        ZPlayerPrefs.Initialize("BlankSpaceStudios", "3f61739c6324fa969fb425e0d81e63c471de07b75cc062080345ad69de732c8d");
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
		ShowCat (ZPlayerPrefs.GetInt("PlayerNum"));
	}
	
	// Update is called once per frame
	void Update () {
        // Check if player meets requirements for character
        CheckUnlock();
	}

	public void ShowNext(){
		menuC.PlayOneShot (menuClick);
		ShowCat (catNum + 1);
	}

	public void ShowPrevious(){
		menuC.PlayOneShot (menuClick);
		ShowCat (catNum - 1);
	}

    public void CheckUnlock()
    {
        // Doge
        // Need 30 score to play as Doge
        // Should write code that detects if there is a requirement and do this automatically

        // Need 30 Score to play as Doge
        if (catNum == 6 && highScore < 30)
        {
                // Less than 30 score and not bought Doge
                // Set requirement notification on
                playerReq.SetActive(true);
                SpriteRenderer dogeSprite = CatList[6].GetComponent<SpriteRenderer>();
                Image dogeName = CatList[6].GetComponentInChildren<Image>();
                dogeSprite.color = new Color32(61, 61, 61, 255);
                dogeName.color = new Color32(61, 61, 61, 255);
                selectButton.SetActive(false);
                buyButton.SetActive(true);
                buyButton2.SetActive(false);
        }
        // Hamilton
        // Need 50 score to play as Hamilton
        // Should write code that detects if there is a requirement and do this automatically
        else if (catNum == 7 && highScore < 50)
        {
                // Less than 50 score and not bought Hamilton
                // Set requirement notification on
                playerReq2.SetActive(true);
                SpriteRenderer hamiltonSprite = CatList[7].GetComponent<SpriteRenderer>();
                Image hamiltonName = CatList[7].GetComponentInChildren<Image>();
                hamiltonSprite.color = new Color32(61, 61, 61, 255);
                hamiltonName.color = new Color32(61, 61, 61, 255);
                selectButton.SetActive(false);
                buyButton.SetActive(false);
                buyButton2.SetActive(true);
        }
        else
        {
            // Set requirement notification off
            playerReq.SetActive(false);
            playerReq2.SetActive(false);
            selectButton.SetActive(true);
            buyButton.SetActive(false);
            buyButton2.SetActive(false);
        }
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
        menuC.PlayOneShot(menuClick);
        ZPlayerPrefs.SetString("Player", Players[catNum].catName);
		ZPlayerPrefs.SetInt("PlayerNum", catNum);
		StartCoroutine(LoadCat());
  	}

	IEnumerator LoadCat(){
		yield return new WaitForSeconds (menuClick.length-0.4f);
		SceneManager.LoadScene ("This Side Up");
	}
}
