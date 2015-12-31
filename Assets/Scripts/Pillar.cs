using UnityEngine;
using System.Collections;

public class Pillar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.tag = "Pillar";
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 stagePos = Camera.main.WorldToScreenPoint (transform.position);
		if (stagePos.x < -60) {
			Destroy (gameObject);
		}
	}

	void Scroll() {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (-3f, 0f);
	}

	void StopScroll() {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 0f);
	}
}
