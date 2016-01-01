using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	public float chargePower = 0;
	private float catPosx, catPosy = 0;

	// Use this for initialization
	void Start () {
		tag = "Power";
		GameObject cat = GameObject.FindGameObjectWithTag ("Player");
		catPosx = cat.gameObject.transform.position.x;
		catPosy = cat.gameObject.transform.position.y;
		transform.localScale = new Vector2 (0f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		GameObject cat = GameObject.FindGameObjectWithTag ("Player");
		catPosx = cat.gameObject.transform.position.x;
		catPosy = cat.gameObject.transform.position.y;
		chargePower = Mathf.Min (chargePower + Time.deltaTime, 1f);
		transform.localScale = new Vector2 (chargePower, 1f);
		transform.position = new Vector2 (catPosx - 0.5f + chargePower / 2, catPosy + 1);
	}
}
