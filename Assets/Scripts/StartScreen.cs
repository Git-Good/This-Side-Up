using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour {

    public GameObject GameTitle;
    public GameObject UIButtons;
    //public GameObject ScoreUnits;
    //public GameObject ScoreTens;
    //public GameObject ScoreHundreds;

    public bool tapped = false;

	// Use this for initialization
	void Start () {
        GameTitle.SetActive(true);
        UIButtons.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
	    if (tapped != false)
        {
            GameTitle.SetActive(false);
            UIButtons.SetActive(false);
        }
	}

    public void Tapped()
    {
        tapped = true;
    }
}