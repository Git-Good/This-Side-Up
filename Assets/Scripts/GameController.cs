using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject cat;
	public GameObject jumpPower;
	public float jumpForce;
	public float maxJumpForce;

	private bool isCharging = false;

	// Use this for initialization
	void Start () {
		// Change this once character selection is there
		Instantiate (cat);
	}
	
	// Update is called once per frame
	void Update () {
		StartScreen ss = this.GetComponent("StartScreen") as StartScreen;
		if (ss.userInput != false) {
			if (Input.GetButtonDown ("Jump") && GameObject.FindWithTag ("Player").GetComponent<Rigidbody2D> ().velocity.y == 0 && !isCharging) {
				GameObject jumpBar = Instantiate (jumpPower) as GameObject;
				isCharging = true;
			}

			if (Input.GetButtonUp ("Jump") && GameObject.FindWithTag ("Player").GetComponent<Rigidbody2D> ().velocity.y == 0 && isCharging) {
				isCharging = false;
				GameObject powerObject = GameObject.FindWithTag ("Power");
				Jump jump = powerObject.GetComponent ("Jump") as Jump;
				Destroy (GameObject.FindWithTag ("Power"));
				GameObject.FindWithTag ("Player").SendMessage ("Jump", maxJumpForce * jump.chargePower + 400);
			}
		}
	}
}
