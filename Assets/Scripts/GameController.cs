using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject cat;
	public GameObject jumpPower;
	public float jumpForce;
	public float maxJumpForce;

	private bool isCharging = false;
	private float catVel;

	void Awake() {
		if (PlayerPrefs.GetString ("Player") == "") {
			// Spawn default if player has never chosen a cat before
			PlayerPrefs.SetString ("Player", "Tigger");
		}
	}

	// Use this for initialization
	void Start () {
		// Change this once character selection is there
		Instantiate (Resources.Load ("Characters/" + PlayerPrefs.GetString ("Player")), transform.position, Quaternion.identity);
		// Don't let screen turn off
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
	
	// Update is called once per frame
	void Update () {
		// Find a way to recode this so update won't have to run GetComponent and FindWithTag
		StartScreen ss = this.GetComponent ("StartScreen") as StartScreen;
		CatScript cs = GameObject.FindObjectOfType<CatScript>();
		catVel = cs.GetComponent<Rigidbody2D> ().velocity.y;
		if (ss.userInput != false && cs.lose != true) {
			if (Input.GetButtonDown ("Jump") && catVel == 0 && !isCharging) {
				GameObject jumpBar = Instantiate (jumpPower) as GameObject;
				isCharging = true;
			}

			if (Input.GetButtonUp ("Jump") && catVel == 0 && isCharging) {
				isCharging = false;
				GameObject powerObject = GameObject.FindWithTag ("Power");
				Jump jump = powerObject.GetComponent ("Jump") as Jump;
				Destroy (GameObject.FindWithTag ("Power"));
				GameObject.FindWithTag ("Player").SendMessage ("Jump", maxJumpForce * jump.chargePower + 380);
			}
		}
	}
}
