using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	private static int score { get; set; }
	static int highScore;
	Text scoreText, highScoreText;
	bool newScore = false;

	public AudioClip scoreSound;
	AudioSource scoreS;

	void Awake(){
		//PlayerPrefs.DeleteAll ();
		scoreS = GetComponent<AudioSource> ();
	}

	void Start(){
		newScore = false;
		score = 0;
		highScore = PlayerPrefs.GetInt ("HighScore");
		//Debug.Log("High Score: " + PlayerPrefs.GetInt ("HighScore"));
		scoreText = gameObject.GetComponent<Text> ();
		//highScoreText = gameObject.GetComponent<Text> ();
	}

	public void AddPoint(){
		scoreS.PlayOneShot (scoreSound);
		score++;
		scoreText.text = "" + score;
		if (score > highScore) {
			newScore = true;
			scoreText.color = new Color32 (238, 232, 170, 255);
			highScore = score;
			PlayerPrefs.SetInt("HighScore", highScore);
		}
	}

	public void ShowHighScore () {
		if (newScore == true) {
			Debug.Log ("Changed HS Color");
			highScoreText.color = new Color32 (238, 232, 170, 255);
		}
		highScoreText = gameObject.GetComponent<Text> ();
		highScoreText.text = "best: " + highScore;
	}

	public void OnDestroy(){
		PlayerPrefs.SetInt ("HighScore", highScore);
	}
}
