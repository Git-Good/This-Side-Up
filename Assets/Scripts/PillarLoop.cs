﻿using UnityEngine;
using System.Collections;

public class PillarLoop : MonoBehaviour {

	int initPillars = 3;
	float minPillar = -2.5f;
	float maxPillar = 0.07f;

	void Start() {
		GameObject[] pillars = GameObject.FindGameObjectsWithTag ("Pillar");

		foreach (GameObject pillar in pillars) {
			if (pillar.name != "Table") {
				Vector3 pos = pillar.transform.position;
				pos.y = Random.Range (minPillar, maxPillar);
				pillar.transform.position = pos;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		float widthOfPillar = ((BoxCollider2D)collider).size.x;
		//Debug.Log (widthOfPillar);
		Vector3 pos = collider.transform.position;
		pos.x += widthOfPillar * initPillars;
		if (collider.name == "Table") {
			// Do nothing because we don't need to loop the table
			return;
		}
		if (collider.tag == "Pillar") {
			pos.y = Random.Range (minPillar, maxPillar);
		}

		//Debug.Log ("Loop Pillar");
		collider.transform.position = pos;
	}
}