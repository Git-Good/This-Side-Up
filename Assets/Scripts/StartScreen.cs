using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {

    public GameObject GameTitle;
    public GameObject TimeTrialTitle;
    public GameObject UIButtons;
    //public GameObject LeaderboardButton;
    //public GameObject TimeTrialLeaderboard;
	public GameObject ScoreText;
	public GameObject HighScoreText;
	public GameObject instructions;
    public GameObject timer;
	public bool userInput = false;

	public AudioClip menuClick;
	AudioSource menuC;

    private bool tapped = false;
	private bool lose = false;
	// static so that reloading the scene will not change the variable
	private static bool restart = false;
    private static bool restartTimeTrial = false;
    public bool timeTrial = false;

	void Awake(){
		menuC = GetComponent<AudioSource> ();
	}

	// Use this for initialization
	void Start () {
        if (restartTimeTrial == true && timeTrial == true)
        {
            timer.SetActive(true);
            instructions.SetActive(true);
            GameTitle.SetActive(false);
            UIButtons.SetActive(false);
            ScoreText.SetActive(true);
            userInput = true;
        }
        else if (restart != true) {
            instructions.SetActive(false);
            GameTitle.SetActive(true);
            UIButtons.SetActive(true);
            ScoreText.SetActive(false);
            HighScoreText.SetActive(false);
            userInput = false;
        }
        else {
            instructions.SetActive(true);
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
            timer.SetActive(false);
            GameTitle.SetActive(false);
            UIButtons.SetActive(false);
			ScoreText.SetActive(true);
			userInput = true;
        }
        else if (timeTrial == true && lose != true)
        {
            timer.SetActive(true);
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

    public void RestartTimeTrial()
    {
        SceneManager.LoadScene("This Side Up");
        restart = false;
        timeTrial = true;
        restartTimeTrial = true;
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

    public void LoseTimeTrial()
    {
        lose = true;
        restartTimeTrial = true;
        ShowHighScore();
    }

    public void Tapped()
    {
		menuC.PlayOneShot (menuClick);
        restartTimeTrial = false;
		StartCoroutine (MenuSound ());
    }

	public void CharSelect(){
		menuC.PlayOneShot (menuClick);
		StartCoroutine (LoadCatSelect ());
	}

    public void TimeTrial()
    {
        menuC.PlayOneShot(menuClick);
        StartCoroutine(LoadTimeTrial());
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

    IEnumerator LoadTimeTrial()
    {
        timeTrial = true;
        yield return new WaitForSeconds(menuClick.length - 0.4f);
        instructions.SetActive(true);
        timer.SetActive(true);
        if (lose == true)
        {
            RestartTimeTrial();
        }
    }
}