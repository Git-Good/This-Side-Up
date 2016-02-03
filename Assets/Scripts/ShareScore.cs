using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class ShareScore : MonoBehaviour {
	private int HScore;
	public AudioClip menuClick;
	AudioSource menuC;

	void Awake(){
		menuC = GetComponent<AudioSource> ();
	}

	public void SendScore() {
		menuC.PlayOneShot (menuClick);
		HScore = PlayerPrefs.GetInt ("HighScore");
		StartCoroutine (LoadLeaderboard ());
	}

	IEnumerator LoadLeaderboard(){
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
}
