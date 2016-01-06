using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.tag = "Background";
	}

	void ScrollBG() {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (-1f, 0f);
	}

	void StopScrollBG() {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 0f);
	}
}