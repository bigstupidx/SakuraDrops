using UnityEngine;
//using UnityEngine.Advertisements;

public class AdManager : Singleton<AdManager> {
	public int requestInterstitialCount;
	public int rewardedVideoZoneCount;
	private bool mIsShow;
	GoogleMobileAdBanner banner;

	// Use this for initialization
	void Start () {
		rewardedVideoZoneCount = 0;
		requestInterstitialCount = 0;
		mIsShow = false;

		//Required
		GoogleMobileAd.Init();
	}
	
	// Update is called once per frame
	void Update () {
//		if (mIsShow == true) {
//			if (Advertisement.IsReady("rewardedVideoZone")) {
//				if (rewardedVideoZoneCount <= 5) {
//					rewardedVideoZoneCount++;
//					AchievementManager.it.OpenLoadLeaderBoards ();
//				} else {
//					rewardedVideoZoneCount = 0;
//					var options = new ShowOptions { resultCallback = HandleShowResult };
//					Advertisement.Show ("rewardedVideoZone", options);
//				}
//
//				mIsShow = false;
//			}
//		}

		if (requestInterstitialCount >= 5) {
			requestInterstitialCount = 0;
			RequestInterstitialAdmob ();
		}
	}

	// RequestInterstitialAdmob
	private void RequestInterstitialAdmob() {
		GoogleMobileAd.StartInterstitialAd ();
	}

	// RequestInterstitial
	public void RequestInterstitial()
	{
		mIsShow = true;
	}

//	private void HandleShowResult(ShowResult result)
//	{
//		switch (result)
//		{
//		case ShowResult.Finished:
//			Debug.Log ("The ad was successfully shown.");
//			break;
//		case ShowResult.Skipped:
//			Debug.Log("The ad was skipped before reaching the end.");
//			break;
//		case ShowResult.Failed:
//			Debug.LogError("The ad failed to be shown.");
//			break;
//		}
//	}
}
