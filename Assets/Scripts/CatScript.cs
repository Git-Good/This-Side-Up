using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CatScript : MonoBehaviour {

	public bool lose = false;
	public bool isGounded = false;
	public AudioClip thudSound;
	public AudioClip meowSound;
	AudioSource thud;
	AudioSource meow;

    private static bool isInTimeTrial;

    void Awake(){
		thud = GetComponent<AudioSource> ();
		meow = GetComponent<AudioSource> ();
	}

	// Use this for initialization
	void Start () {
		transform.position = new Vector2 (-2f, -0.4860704f);
		tag = "Player";
	}

	// Update is called once per frame
	void Update () {
        // Read the Time Trial variable
        isInTimeTrial = StartScreen.timeTrial;
        // Check what happens when cat falls off map
        if (this.transform.position.y < -5f) {
			this.GetComponent<Rigidbody2D> ().isKinematic = true;
			lose = true;
			StartCoroutine (LoseGame ());
		}
	}

	void JumpAnim() {
		GetComponent<Animator> ().SetTrigger ("Jump");
	}

	void LandAnim() {
		GetComponent<Animator> ().SetTrigger ("Land");
	}

	void Jump (float jumpForce){
		GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f, jumpForce));
		GameObject[] pillars = GameObject.FindGameObjectsWithTag ("Pillar");
		GameObject[] backgrounds = GameObject.FindGameObjectsWithTag ("Background");
		foreach (GameObject pillar in pillars) {
			pillar.SendMessage ("Scroll");
		}
		foreach (GameObject background in backgrounds) {
			background.SendMessage ("ScrollBG");
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		GameObject[] pillars = GameObject.FindGameObjectsWithTag ("Pillar");
		GameObject[] backgrounds = GameObject.FindGameObjectsWithTag ("Background");
		foreach (GameObject pillar in pillars) {
			pillar.SendMessage ("StopScroll");
		}
		foreach (GameObject background in backgrounds) {
			background.SendMessage ("StopScrollBG");
		}

		if (collision.gameObject.tag == "Box" || collision.gameObject.name == "Table") {
			isGounded = true;
		}
	}

	void OnCollisionExit2D(Collision2D collision){
		if (collision.gameObject.tag == "Box") {
			isGounded = false;
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Ceiling") {
			thud.PlayOneShot (thudSound);
		}
		if (collider.tag == "Floor" || collider.tag == "Ceiling") {
			GetComponent<Animator> ().SetTrigger ("Dizzy");
			if (lose != true) {
				meow.PlayOneShot (meowSound);
				lose = true;
				StartCoroutine (LoseGame ());
			}
		}
	}

	IEnumerator LoseGame(){
		GameObject startScreen = GameObject.FindWithTag ("Start Screen");
		yield return new WaitForSeconds(1);
        if (isInTimeTrial == true)
        {
            startScreen.SendMessage("LoseTimeTrial");
        }
        else
        {
            startScreen.SendMessage("Lose");
        }
	}
}