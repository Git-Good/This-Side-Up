using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	public float chargePower = 0;

	// Use this for initialization
	void Start () {
		tag = "Power";
		transform.localScale = new Vector2 (0f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		chargePower = Mathf.Min (chargePower + Time.deltaTime, 1f);
		transform.localScale = new Vector2 (chargePower, 1f);
		transform.position = new Vector2 (-3.0f + chargePower / 2, 2.15f);
	}
}
