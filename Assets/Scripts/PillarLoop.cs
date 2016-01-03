using UnityEngine;
using System.Collections;

public class PillarLoop : MonoBehaviour {

	public GameObject[] pillarList;
	//int initPillars = 3;
	float minPillar = -3.67f;
	float maxPillar = 0.03f;

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
		//float widthOfPillar = ((BoxCollider2D)collider).size.x;
		//Debug.Log (widthOfPillar);
		Vector3 pos = collider.transform.position;
		pos.x = 4.5f;
//		pos.x += widthOfPillar * initPillars;

		if (collider.name == "Table") {
			// Do nothing because we don't need to loop the table
			// Remove the table as well
			Destroy(collider.gameObject);
			return;
		}
		if (collider.tag == "Player") {
			// Do nothing
			return;
		}
		if (collider.tag == "Pillar") {
			// Randomized pillar height
			pos.y = Random.Range (minPillar, maxPillar);
		}
			
		Destroy(collider.gameObject);
		PillarSpawn(pos);
	}

	void PillarSpawn(Vector3 pos){
		// Randomly spawn a pillar from the list
		// This allows you to spawn any pillar randomly
		int i = Random.Range (0, pillarList.Length);
		Instantiate (pillarList [i], pos, Quaternion.identity);
	}
}
