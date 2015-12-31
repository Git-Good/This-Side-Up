using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CatScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.position = new Vector2 (-2f, 2f);
		tag = "Player";
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 stagePos = Camera.main.WorldToScreenPoint (transform.position);
		if (stagePos.y < -2.24f) {
			// What happens when cat falls off the pillar
		}
	}

	void Jump (float jumpForce){
		GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f, jumpForce));
		GameObject[] pillars = GameObject.FindGameObjectsWithTag ("Pillar");
		foreach (GameObject pillar in pillars) {
			pillar.SendMessage ("Scroll");
		}
	}

	void OnCollisionEnter2D() {
		GameObject[] pillars = GameObject.FindGameObjectsWithTag ("Pillar");
		foreach (GameObject pillar in pillars) {
			pillar.SendMessage ("StopScroll");
		}
	}
}
