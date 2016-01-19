using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	private static int score { get; set; }
	static int highScore;
	static int oldScore;
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

	}

	public void AddPoint(){
		scoreS.PlayOneShot (scoreSound);
		score++;
		scoreText.text = "" + score;
		oldScore = score;
		if (score > highScore) {
			newScore = true;
			scoreText.color = new Color32 (238, 232, 170, 255);
			oldScore = score + 1;
			highScore = score;
			PlayerPrefs.SetInt("HighScore", highScore);
		}
	}

	public void ShowHighScore () {
		highScoreText = gameObject.GetComponent<Text> ();
		highScoreText.text = "best: " + highScore;

		if (oldScore >= highScore) {
			Debug.Log ("Changed HS Color");
			highScoreText.color = new Color32 (238, 232, 170, 255);
			//highScoreText.color = new Color32 (0, 0, 0, 0);
			oldScore = 0;
		}
	}

	public void OnDestroy(){
		PlayerPrefs.SetInt ("HighScore", highScore);
	}
}
