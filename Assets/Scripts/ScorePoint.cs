using UnityEngine;
using System.Collections;

public class ScorePoint : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Player") {
			gameObject.SetActive (false);
			GameObject scoreText = GameObject.FindWithTag ("ScoreText");
			scoreText.SendMessage ("AddPoint");
		}
	}
}