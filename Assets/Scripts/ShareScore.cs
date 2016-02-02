using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class ShareScore : MonoBehaviour {
	private int HScore;

	public void SendScore() {
		HScore = PlayerPrefs.GetInt ("HighScore");
		// Don't share score if 0
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
