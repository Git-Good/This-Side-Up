using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject cat;
	public GameObject pillar;
	public GameObject jumpPower;
	public float jumpForce;
	public float maxJumpForce;

	private bool isCharging = false;
	private float pillarGap = 2f;

	// Use this for initialization
	void Start () {
		// Change this once character selection is there
		Instantiate (cat);
		placePillar (-2f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Jump") && GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().velocity.y==0 && !isCharging) {
			GameObject jumpBar = Instantiate (jumpPower) as GameObject;
			isCharging = true;
			GameObject[] pillars = GameObject.FindGameObjectsWithTag ("Pillar");
			float maxPillarDistance = 0f;
			foreach (GameObject pillar in pillars) {
				maxPillarDistance = Mathf.Max (maxPillarDistance, pillar.transform.position.x);
			}

			if (maxPillarDistance < 9f) {
				placePillar (maxPillarDistance + pillarGap + Random.value*(pillarGap));
			}
		}

		if (Input.GetButtonUp ("Jump") && GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().velocity.y==0 && isCharging) {
			isCharging = false;
			GameObject powerObject = GameObject.FindWithTag ("Power");
			Jump jump = powerObject.GetComponent ("Jump") as Jump;
			Destroy (GameObject.FindWithTag ("Power"));
			GameObject.FindWithTag ("Player").SendMessage ("Jump", maxJumpForce * jump.chargePower+50);
		}
	}

	void placePillar(float posX){
		if (posX < 9f) {
			Instantiate (pillar);
			pillar.transform.position = new Vector2 (posX, -2f + Random.value * 2f);
			posX += pillarGap + Random.value*(pillarGap);
			placePillar (posX);
		}
	}
}
