using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

    // Time Trial
    public float startTime = 120f;
    private string currentTime;
    Text timerText;

    // Whistle Sound
    public AudioClip whistleSound;
    AudioSource whistleS;

    void Start()
    {
        whistleS = GetComponent<AudioSource>();
        currentTime = startTime.ToString();
        CountDown();
    }

    void Update()
    {
        GameController gc = GameObject.FindObjectOfType<GameController>();
        if (gc.startedGame == true)
        {
            startTime -= Time.deltaTime;
            currentTime = string.Format("{0:0.0}", startTime);
        }
        
    }

    public void CountDown()
    {
        timerText = gameObject.GetComponent<Text>();
        timerText.text = currentTime;
        if (startTime <= 5)
        {
            timerText.color = new Color32(240, 128, 128, 255);
        }
        if (startTime <= 0)
        {
            whistleS.PlayOneShot(whistleSound);
            CatScript cs = GameObject.FindObjectOfType<CatScript>();
            startTime = 0f;
            cs.lose = true;
            StartCoroutine(LoseTimeTrial());
        }
    }

    IEnumerator LoseTimeTrial()
    {
        GameObject startScreen = GameObject.FindWithTag("Start Screen");
        yield return new WaitForSeconds(1);
        startScreen.SendMessage("LoseTimeTrial");
    }
}
