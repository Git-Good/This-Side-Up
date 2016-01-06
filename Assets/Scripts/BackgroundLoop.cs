using UnityEngine;
using System.Collections;

public class BackgroundLoop : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider){
		Vector3 pos = collider.transform.position;
		pos.x = 5.05f;

		if (collider.name == "Table" || collider.tag == "Player" || collider.tag == "Pillar") {
			// Do nothing
			return;
		}

		collider.transform.position = pos;
		//Debug.Break ();
	}
}

