using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AchievementManager : Singleton<AchievementManager> {
	public GameObject AchievementIcon;

	public const string LEADERBOARD_ID_SAKURA_DROPS = "Sakura Drops";

	// Use this for initialization
	void Start () {
		if (AchievementIcon != null) {
			AchievementIcon.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Connection
	public void Connection() {
		UM_GameServiceManager.OnPlayerConnected += OnPlayerConnected;
		UM_GameServiceManager.OnPlayerDisconnected += OnPlayerDisconnected;

		UM_GameServiceManager.Instance.Connect();

		if(UM_GameServiceManager.instance.ConnectionSate == UM_ConnectionState.CONNECTED) {
			OnPlayerConnected();
		}
	}

	// OnPlayerConnected
	private void OnPlayerConnected() {
		if (AchievementIcon != null) {
			AchievementIcon.SetActive (true);
		}
	}

	private void OnPlayerDisconnected() {
	}

	// OpenLoadLeaderBoards
	public void OpenLoadLeaderBoards() {
		if (UM_GameServiceManager.instance.ConnectionSate == UM_ConnectionState.CONNECTED) {
			UM_GameServiceManager.Instance.ShowLeaderBoardUI (LEADERBOARD_ID_SAKURA_DROPS);
		}
	}

	// OpenAchievementsUI
	public void OpenAchievementsUI() {
		if (UM_GameServiceManager.instance.ConnectionSate == UM_ConnectionState.CONNECTED) {
			UM_GameServiceManager.Instance.ShowAchievementsUI ();
		}
	}

	// SubmitScore
	public void SubmitScore(string leaderboardId, int value) {
		Debug.Log (leaderboardId + " / " + value.ToString());
		if (UM_GameServiceManager.instance.ConnectionSate == UM_ConnectionState.CONNECTED) {
			UM_GameServiceManager.Instance.SubmitScore (leaderboardId, value);
		}
	}
}
