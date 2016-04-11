using UnityEngine;
using System.Collections;

public class ScorePoint : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider){
        CatScript cs = GameObject.FindObjectOfType<CatScript>();
        if (collider.tag == "Player" && cs.lose != true) {
			gameObject.SetActive (false);
			GameObject scoreText = GameObject.FindWithTag ("ScoreText");
			scoreText.SendMessage ("AddPoint");
		}
	}
}