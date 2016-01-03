using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	private static int score { get; set; }
	static int highScore;
	Text scoreText, highScoreText;

	void Start(){
		score = 0;
		highScore = PlayerPrefs.GetInt ("HighScore");
		//Debug.Log("High Score: " + PlayerPrefs.GetInt ("HighScore"));
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
		highScoreText = gameObject.GetComponent<Text> ();
		highScoreText.text = "best: " + highScore;
	}

	public void OnDestroy(){
		PlayerPrefs.SetInt ("HighScore", highScore);
	}
}
