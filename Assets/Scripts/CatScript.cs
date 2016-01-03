using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CatScript : MonoBehaviour {

	public bool lose = false;

	// Use this for initialization
	void Start () {
		transform.position = new Vector2 (-2f, -0.4860704f);
		tag = "Player";
	}

	// Update is called once per frame
	void Update () {
		// Check what happens when cat falls off map
		if (this.transform.position.y < -5f) {
			lose = true;
			StartCoroutine (LoseGame ());
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

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Floor") {
			lose = true;
			StartCoroutine (LoseGame ());
		}
	}

	IEnumerator LoseGame(){
		GameObject startScreen = GameObject.FindWithTag ("Start Screen");
		yield return new WaitForSeconds(1);
		startScreen.SendMessage ("Lose");
	}
}
