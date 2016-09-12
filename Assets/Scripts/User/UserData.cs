using UnityEngine;
using System.Collections.Generic;

public class UserData {
	public bool isSound = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public string currentScore;

	// SetScore
	public void SetScore(int value)
	{
		if (GetScore () != value) {
			currentScore = GameUtil.it.Encrypt (value.ToString ());
		}
	}

	// GetScore
	public int GetScore()
	{
		if (currentScore != null) {
			return int.Parse(GameUtil.it.Decrypt (currentScore));
		}

		return 0;
	}

	public string currentBestScore;

	// SetBestScore
	public void SetBestScore(int value)
	{
		if (GetBestScore () != value) {
			currentBestScore = GameUtil.it.Encrypt (value.ToString ());
		}
	}

	// GetBestScore
	public int GetBestScore()
	{
		if (currentBestScore != null) {
			return int.Parse(GameUtil.it.Decrypt (currentBestScore));
		}

		return 0;
	}
}
