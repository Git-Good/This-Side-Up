using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	private int score = 0;
	private int highScore;
	Text scoreText, highScoreText;

	void Start(){
		score = 0;
		scoreText = gameObject.GetComponent<Text> ();
		//highScoreText = gameObject.GetComponent<Text> ();
	}

	public void AddPoint(){
		score++;
		scoreText.text = "" + score;
		if (score > highScore) {
			highScore = score;
			PlayerPrefs.SetInt("HighScore", highScore);
		}
	}

	public void ShowHighScore () {
		highScore = PlayerPrefs.GetInt ("HighScore");
		highScoreText = gameObject.GetComponent<Text> ();
		highScoreText.text = "Best: " + highScore;
	}

	public void OnDestroy(){
		PlayerPrefs.SetInt ("HighScore", highScore);
	}
}
