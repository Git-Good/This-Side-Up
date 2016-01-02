using UnityEngine;
using System.Collections;

public class Pillar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.tag = "Pillar";
	}

	void Scroll() {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (-4.2f, 0f);
	}

	void StopScroll() {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 0f);
	}
}
