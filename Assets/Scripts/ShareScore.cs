using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class ShareScore : MonoBehaviour {
	private int HScore;
    private int TTHScore;
	public AudioClip menuClick;
	AudioSource menuC;

    private static bool isInTimeTrial;

    void Awake(){
		menuC = GetComponent<AudioSource> ();
	}

    void Update()
    {
        // Read the Time Trial variable
        isInTimeTrial = StartScreen.timeTrial;
    }

	public void SendScore() {
        if (isInTimeTrial == true)
        {
            menuC.PlayOneShot(menuClick);
            TTHScore = PlayerPrefs.GetInt("TimeTrialHS");
            StartCoroutine(LoadTTLeaderboard());
        }
        else
        {
            menuC.PlayOneShot(menuClick);
            HScore = PlayerPrefs.GetInt("HighScore");
            StartCoroutine(LoadLeaderboard());
        }
		
	}

	IEnumerator LoadLeaderboard(){
        //Debug.Log("Normal Leaderboard");
		yield return new WaitForSeconds (menuClick.length-0.4f);
		if (PlayGamesPlatform.Instance.localUser.authenticated) {
			PlayGamesPlatform.Instance.ReportScore (HScore, "CgkIsJ6QpO0HEAIQAA", (bool success) => {
				PlayGamesPlatform.Instance.ShowLeaderboardUI ("CgkIsJ6QpO0HEAIQAA");
			});
		} else {
			PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder ().Build ();
			GooglePlayGames.PlayGamesPlatform.InitializeInstance (config);
			//GooglePlayGames.PlayGamesPlatform.DebugLogEnabled = true;
			GooglePlayGames.PlayGamesPlatform.Activate ();
			PlayGamesPlatform.Instance.localUser.Authenticate((bool success) => {
				PlayGamesPlatform.Instance.ReportScore (HScore, "CgkIsJ6QpO0HEAIQAA", (bool success2) => {
					PlayGamesPlatform.Instance.ShowLeaderboardUI ("CgkIsJ6QpO0HEAIQAA");
				});
			});
		}
	}

    IEnumerator LoadTTLeaderboard()
    {
        //Debug.Log("Time Trial Leaderboard");
        yield return new WaitForSeconds(menuClick.length - 0.4f);
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ReportScore(TTHScore, "CgkIsJ6QpO0HEAIQCQ", (bool success) => {
                PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkIsJ6QpO0HEAIQCQ");
            });
        }
        else {
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
            GooglePlayGames.PlayGamesPlatform.InitializeInstance(config);
            //GooglePlayGames.PlayGamesPlatform.DebugLogEnabled = true;
            GooglePlayGames.PlayGamesPlatform.Activate();
            PlayGamesPlatform.Instance.localUser.Authenticate((bool success) => {
                PlayGamesPlatform.Instance.ReportScore(TTHScore, "CgkIsJ6QpO0HEAIQCQ", (bool success2) => {
                    PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkIsJ6QpO0HEAIQCQ");
                });
            });
        }
    }
}
