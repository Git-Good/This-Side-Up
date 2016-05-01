using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

    public GameObject cat;
    public GameObject jumpPower;
    public float jumpForce;
    public float maxJumpForce;
    public AudioClip jumpSound;
    AudioSource jumpS;

    private bool isCharging = false;
    public bool startedGame = false;

    private static bool isInTimeTrial;

    void Awake()
    {
        ZPlayerPrefs.Initialize("BlankSpaceStudios", "3f61739c6324fa969fb425e0d81e63c471de07b75cc062080345ad69de732c8d");
        if (ZPlayerPrefs.GetString("Player") == "")
        {
            // Spawn default if player has never chosen a cat before
            ZPlayerPrefs.SetString("Player", "Tigger");
        }
        jumpS = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start()
    {
        Instantiate(Resources.Load("Characters/" + ZPlayerPrefs.GetString("Player")), transform.position, Quaternion.identity);
        // Don't let screen turn off
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    // Update is called once per frame
    void Update()
    {
        // Read the Time Trial variable
        isInTimeTrial = StartScreen.timeTrial;
        // Find a way to recode this so update won't have to run GetComponent and FindWithTag
        StartScreen ss = this.GetComponent("StartScreen") as StartScreen;
        CatScript cs = GameObject.FindObjectOfType<CatScript>();

        if (ss.userInput != false && cs.lose != true)
        {
            if (Input.GetButtonDown("Jump") && cs.isGounded && !isCharging)
            {
                startedGame = true;
                ss.SendMessage("RemoveInstructions");
                cs.SendMessage("JumpAnim");
                GameObject jumpBar = Instantiate(jumpPower) as GameObject;
                isCharging = true;
            }

            if (Input.GetButtonUp("Jump") && cs.isGounded && isCharging)
            {
                cs.isGounded = false;
                cs.SendMessage("LandAnim");
                isCharging = false;
                jumpS.PlayOneShot(jumpSound);
                GameObject powerObject = GameObject.FindWithTag("Power");
                Jump jump = powerObject.GetComponent("Jump") as Jump;
                Destroy(GameObject.FindWithTag("Power"));
                GameObject.FindWithTag("Player").SendMessage("Jump", maxJumpForce * jump.chargePower + 380);
            }
        }
        // Time Trial Timer
        if (cs.lose != true && startedGame == true)
        {

            GameObject timerText = GameObject.FindWithTag("TimerText");
            if (timerText != null)
            {
                timerText.SendMessage("CountDown");
            }
        }
        if (isInTimeTrial == true && cs.lose == true)
        {
            startedGame = false;
        }
        if (cs.lose == true || cs.isGounded == false)
        {
            Destroy(GameObject.FindWithTag("Power"));
        }
    }
}
