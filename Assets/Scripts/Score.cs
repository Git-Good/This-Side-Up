using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	private int score = 0;
	private int highScore = 0;
	Text scoreText;

	void Start(){
		score = 0;
		highScore = PlayerPrefs.GetInt ("HighScore");
		//Debug.Log ("HighScore: " + highScore);
		scoreText = gameObject.GetComponent<Text> ();
	}

	void Update () {
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
		
	}

	public void OnDestroy(){
		PlayerPrefs.SetInt ("HighScore", highScore);
	}
}
