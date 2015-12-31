using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour {

    public GameObject GameTitle;
    public GameObject UIButtons;
	public bool userInput = false;
    //public GameObject ScoreUnits;
    //public GameObject ScoreTens;
    //public GameObject ScoreHundreds;

    public bool tapped = false;

	// Use this for initialization
	void Start () {
        GameTitle.SetActive(true);
        UIButtons.SetActive(true);
		userInput = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if (tapped != false)
        {
            GameTitle.SetActive(false);
            UIButtons.SetActive(false);
			userInput = true;
        }
	}

    public void Tapped()
    {
        tapped = true;
    }
}