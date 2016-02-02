using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using SecPlayerPrefs;

public class Score : MonoBehaviour {

	private static int score { get; set; }
	static int highScore;
	static int oldScore;
	Text scoreText, highScoreText;

	public AudioClip scoreSound;
	AudioSource scoreS;

	void Awake(){
		//PlayerPrefs.DeleteAll ();
		scoreS = GetComponent<AudioSource> ();
	}

	void Start(){
		score = 0;
		highScore = SecurePlayerPrefs.GetInt ("HighScore");
		//Debug.Log("High Score: " + SecurePlayerPrefs.GetInt ("HighScore"));
		scoreText = gameObject.GetComponent<Text> ();
	}

	public void AddPoint(){
		scoreS.PlayOneShot (scoreSound);
		score++;
		scoreText.text = "" + score;
		oldScore = score;
		if (score > highScore) {
			scoreText.color = new Color32 (238, 232, 170, 255);
			oldScore = score + 1;
			highScore = score;
			SecurePlayerPrefs.SetInt("HighScore", highScore);
		}
	}

	public void ShowHighScore () {
		highScoreText = gameObject.GetComponent<Text> ();
		highScoreText.text = "best: " + highScore;
		if (oldScore >= highScore) {
			//Debug.Log ("Changed HS Color");
			highScoreText.color = new Color32 (238, 232, 170, 255);
			oldScore = 0;
		}
	}

	public void OnDestroy(){
		SecurePlayerPrefs.SetInt ("HighScore", highScore);
	}
}
