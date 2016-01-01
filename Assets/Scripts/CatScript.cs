using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CatScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.position = new Vector2 (-2f, -0.4860704f);
		tag = "Player";
	}

	// Update is called once per frame
	void Update () {
		// Check what happens when cat falls off map
		if (this.transform.position.y < -5f) {
			SceneManager.LoadScene ("This Side Up");
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
			SceneManager.LoadScene ("This Side Up");
		}
	}
}
