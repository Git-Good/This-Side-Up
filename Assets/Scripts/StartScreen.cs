using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {

    public GameObject GameTitle;
    public GameObject UIButtons;
	public GameObject ScoreText;
	public bool userInput = false;

    public bool tapped = false;

	// Use this for initialization
	void Start () {
        GameTitle.SetActive(true);
        UIButtons.SetActive(true);
		ScoreText.SetActive(false);
		userInput = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if (tapped != false)
        {
            GameTitle.SetActive(false);
            UIButtons.SetActive(false);
			ScoreText.SetActive(true);
			userInput = true;
        }
	}

    public void Tapped()
    {
        tapped = true;
    }

	public void CharSelect(){
		SceneManager.LoadScene ("Character Select");
	}

	public void PrevScene(){
		// Also save the character the player has chosen
		SceneManager.LoadScene ("This Side Up");
	}
}