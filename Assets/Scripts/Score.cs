using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	private static int score { get; set; }
	static int highScore;
    static int timeTrialHS;
	static int oldScore;
    private bool played = false;
	Text scoreText, highScoreText;

	public AudioClip scoreSound;
    public AudioClip beatHighScore;
	AudioSource scoreS;
    AudioSource beatHS;

    private static bool isInTimeTrial;

    void Awake(){
        //PlayerPrefs.DeleteAll ();
        scoreS = GetComponent<AudioSource> ();
        beatHS = GetComponent<AudioSource>();
	}

	void Start(){
		score = 0;
		highScore = PlayerPrefs.GetInt ("HighScore");
        timeTrialHS = PlayerPrefs.GetInt("TimeTrialHS");
		//Debug.Log("High Score: " + PlayerPrefs.GetInt ("HighScore"));
		scoreText = gameObject.GetComponent<Text> ();
	}

    void Update()
    {
        // Read the Time Trial variable
        isInTimeTrial = StartScreen.timeTrial;
    }

	public void AddPoint(){
        scoreS.PlayOneShot (scoreSound);
		score++;
		scoreText.text = "" + score;
		oldScore = score;

        // Time Trial HS
        if (isInTimeTrial == true)
        {
            if (score > timeTrialHS)
            {
                scoreText.color = new Color32(238, 232, 170, 255);
                scoreText.fontSize = 150;
                if (played == false)
                {
                    beatHS.PlayOneShot(beatHighScore);
                    played = true;
                }
                oldScore = score + 1;
                timeTrialHS = score;
                PlayerPrefs.SetInt("TimeTrialHS", timeTrialHS);
            }
        }
        // Normal mode HS
        else if (score > highScore)
        {
            scoreText.color = new Color32(238, 232, 170, 255);
            scoreText.fontSize = 150;
            if (played == false)
            {
                beatHS.PlayOneShot(beatHighScore);
                played = true;
            }
            oldScore = score + 1;
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

	public void ShowHighScore () {
        highScoreText = gameObject.GetComponent<Text> ();

        if (isInTimeTrial == true)
        {
            highScoreText.text = "best: " + timeTrialHS;
            if (oldScore > timeTrialHS)
            {
                //Debug.Log ("Changed HS Color");
                highScoreText.color = new Color32(238, 232, 170, 255);
                oldScore = 0;
            }
        }
        else
        {
            highScoreText.text = "best: " + highScore;
            if (oldScore > highScore)
            {
                //Debug.Log ("Changed HS Color");
                highScoreText.color = new Color32(238, 232, 170, 255);
                oldScore = 0;
            }
        }
		
	}

	public void OnDestroy(){
		PlayerPrefs.SetInt ("HighScore", highScore);
        PlayerPrefs.SetInt("TimeTrialHS", timeTrialHS);
    }
}
