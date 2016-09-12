using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class User : Singleton<User> {
	private const int INIT_SCORE = 0;
	private const int INIT_BEST_SCORE = 0;

	static public bool IsDataLoad = false;

	static bool _isEncrypt = true;
	static UserData _data;

	public UserData GetData() {
		return _data;
	}

	// SaveData
	public void SaveData()
	{
		string jsonString = JsonFx.Json.JsonWriter.Serialize(_data);

		if (_isEncrypt) {
			FileMap.it.writeStringToFile (GameUtil.it.Encrypt (jsonString), "UserData.dat");
		} else {
			FileMap.it.writeStringToFile (jsonString, "UserData.dat");
		}
	}
	
	// LoadData
	public void LoadData()
	{
		IsDataLoad = false;

		string jsonString = FileMap.it.readStringFromFile ("UserData.dat");

		if (jsonString != null) {
			if (_isEncrypt) {
				_data = JsonFx.Json.JsonReader.Deserialize<UserData>(GameUtil.it.Decrypt (jsonString));
			}
			else {
				_data = JsonFx.Json.JsonReader.Deserialize<UserData>(jsonString);
			}

			SetSound (isSound);

			AchievementManager.it.Connection ();

			IsDataLoad = true;
			return;
		}

		Init ();
	}

	// Init
	public void Init()
	{
		if (_data == null) {
			_data = new UserData();
		}

		score = INIT_SCORE;
		bestScore = INIT_BEST_SCORE;

		AchievementManager.it.Connection ();

		IsDataLoad = true;
	}

	// SetSound
	public void SetSound(bool isSound = true)
	{
		if (isSound) {
			SoundManager.PlayConnection("main");
			SoundManager.SetVolume(1f);
		} else {
			SoundManager.SetVolume(0f);
		}
	}

	// isSound
	public bool isSound
	{
		get { return _data.isSound; }
		set {
			_data.isSound = value;

			SetSound (_data.isSound);

			if(IsDataLoad) {
				SaveData();
			}
		}
	}

	// score
	public int score
	{
		get { 
			if (_data == null) {
				return 0;
			}
			return _data.GetScore(); }
		set {
			_data.SetScore(value);

//			if(IsDataLoad) {
//				SaveData();
//			}
		}
	}

	// bestScore
	public int bestScore
	{
		get { 
			if (_data == null) {
				return 0;
			}
			return _data.GetBestScore(); }
		set {
			AchievementManager.it.SubmitScore (AchievementManager.LEADERBOARD_ID_SAKURA_DROPS, value);

			_data.SetBestScore(value);

			if(IsDataLoad) {
				SaveData();
			}
		}
	}
}
