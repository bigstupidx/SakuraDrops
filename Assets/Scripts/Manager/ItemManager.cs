//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections;
//
//public class ItemManager : Singleton<ItemManager> {
//	private const int INIT_CPU_GOLD 		= 100;
//	private const int INIT_GPU_GOLD 		= 5000;
//	private const int INIT_LEFT_ARM_GOLD 	= 10000;
//	private const int INIT_RIGHT_ARM_GOLD 	= 14000;
//	private const int INIT_LEFT_LEG_GOLD 	= 20000;
//	private const int INIT_RIGHT_LEG_GOLD 	= 30000;
//	private const int INIT_ALPHAGO_GOLD 	= 300000;
//
//	public Image addCPU;
//	public Text addCPUCnt;
//	public Text addCPUName;
//	public Text addCPUGold;
//
//	public Image addGPU;
//	public Text addGPUCnt;
//	public Text addGPUName;
//	public Text addGPUGold;
//
//	public Image addLeftArm;
//	public Text addLeftArmCnt;
//	public Text addLeftArmName;
//	public Text addLeftArmGold;
//
//	public Image addRightArm;
//	public Text addRightArmCnt;
//	public Text addRightArmName;
//	public Text addRightArmGold;
//
//	public Image addLeftLeg;
//	public Text addLeftLegCnt;
//	public Text addLeftLegName;
//	public Text addLeftLegGold;
//
//	public Image addRightLeg;
//	public Text addRightLegCnt;
//	public Text addRightLegName;
//	public Text addRightLegGold;
//
//	public Text adsCnt;
//	public Text adsName;
//	public Text adsGold;
//
//	public Image addAlphaGo;
//	public Text addAlphaGoCnt;
//	public Text addAlphaGoName;
//	public Text addAlphaGoGold;
//
//	public Image imageLeftArm;
//	public Image imageRightArm;
//	public Image imageLeftLeg;
//	public Image imageRightLeg;
//
//	private Color mEnableColor = new Color(1f, 1f, 1f, 1f);
//	private Color mDisableColor = new Color(1f, 1f, 1f, 0.25f);
//
//	// Use this for initialization
//	void Start () {
//	
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}
//
//	// UpdateChar
//	public void UpdateChar() {
//		if (User.it.leftArmCnt >= 1) {
//			imageLeftArm.gameObject.SetActive (true);
//		}
//
//		if (User.it.rightArmCnt >= 1) {
//			imageRightArm.gameObject.SetActive (true);
//		}
//
//		if (User.it.leftLegCnt >= 1) {
//			imageLeftLeg.gameObject.SetActive (true);
//		}
//
//		if (User.it.rightLegCnt >= 1) {
//			imageRightLeg.gameObject.SetActive (true);
//		}
//	}
//
//	// InitDisplay
//	public void UpdateDisplay() {
//		string strPower = "";
//		string strCurrent = "";
//		string strCPU = "";
//		string strGPU = "";
//		string strLeftArm = "";
//		string strRightArm = "";
//		string strLeftArmUp = "";
//		string strRightArmUp = "";
//		string strLeftLeg = "";
//		string strRightLeg = "";
//		string strLeftLegUp = "";
//		string strRightLegUp = "";
//		string strAdsDesc = "";
//		string strAdsTitle = "";
//		string strAlphaGo = "";
//		if (Language.CurrentLanguage() == LanguageCode.KO) {
//			strPower = "전력";
//			strCurrent = "현재";
//			strCPU = "CPU 추가";
//			strGPU = "GPU 추가";
//			strLeftArm = "왼팔 추가";
//			strRightArm = "오른팔 추가";
//			strLeftArmUp = "왼팔 업그레이드";
//			strRightArmUp = "오른팔 업그레이드";
//			strLeftLeg = "왼다리 추가";
//			strRightLeg = "오른다리 추가";
//			strLeftLegUp = "왼다리 업그레이드";
//			strRightLegUp = "오른다리 업그레이드";
//			strAdsDesc = "60초 자동 클릭";
//			strAdsTitle = "광고보기";
//			strAlphaGo = "알파고 추가";
//		} else {
//			strPower = "Power";
//			strCurrent = "Current";
//			strCPU = "Add CPU";
//			strGPU = "Add GPU";
//			strLeftArm = "Add left arm";
//			strRightArm = "Add right arm";
//			strLeftArmUp = "left arm Upgrading";
//			strRightArmUp = "right arm Upgrading";
//			strLeftLeg = "Add left leg";
//			strRightLeg = "Add right leg";
//			strLeftLegUp = "left leg Upgrading";
//			strRightLegUp = "right leg Upgrading";
//			strAdsDesc = "60 seconds Auto-Click";
//			strAdsTitle = "Ad view";
//			strAlphaGo = "Add AlphaGo";
//		}
//
//		if (User.it.goldCnt > GetCPUGold ()) {
//			addCPU.color = addCPUCnt.color = addCPUName.color = addCPUGold.color = mEnableColor;
//		} else {
//			addCPU.color = addCPUCnt.color = addCPUName.color = addCPUGold.color = mDisableColor;
//		}
//		addCPUCnt.text = strCurrent + " x" + User.it.CPUCnt.ToString("n0");
//		addCPUName.text = strCPU;
//		if (GetCPUGold () >= double.MaxValue) {
//			addCPUGold.text = "Max " + strPower;
//		} else {
//			addCPUGold.text = StringUtil.FormatCash (GetCPUGold ()) + " " + strPower;
//		}
//
//		if (User.it.GetClickGold() >= 20 && User.it.goldCnt > GetGPUGold ()) {
//			addGPU.color = addGPUCnt.color = addGPUName.color = addGPUGold.color = mEnableColor;
//		} else {
//			addGPU.color = addGPUCnt.color = addGPUName.color = addGPUGold.color = mDisableColor;
//		}
//		addGPUCnt.text = strCurrent + " x" + User.it.GPUCnt.ToString("n0");
//		addGPUName.text = strGPU;
//		if (GetGPUGold () >= double.MaxValue) {
//			addGPUGold.text = "Max " + strPower;
//		} else {
//			addGPUGold.text = StringUtil.FormatCash (GetGPUGold ()) + " " + strPower;
//		}
//
//		if (User.it.goldCnt > GetLeftArmGold ()) {
//			addLeftArm.color = addLeftArmCnt.color = addLeftArmName.color = addLeftArmGold.color = mEnableColor;
//		} else {
//			addLeftArm.color = addLeftArmCnt.color = addLeftArmName.color = addLeftArmGold.color = mDisableColor;
//		}
//		if (User.it.leftArmCnt > 0) {
//			addLeftArmCnt.text = strCurrent + " x" + User.it.leftArmCnt.ToString("n0");
//			addLeftArmName.text = strLeftArmUp;
//		} else {
//			addLeftArmCnt.text = "";
//			addLeftArmName.text = strLeftArm;
//		}
//		if (GetLeftArmGold () >= double.MaxValue) {
//			addLeftArmGold.text = "Max " + strPower;
//		} else {
//			addLeftArmGold.text = StringUtil.FormatCash (GetLeftArmGold ()) + " " + strPower;
//		}
//
//		if (User.it.goldCnt > GetRightArmGold ()) {
//			addRightArm.color = addRightArmCnt.color = addRightArmName.color = addRightArmGold.color = mEnableColor;
//		} else {
//			addRightArm.color = addRightArmCnt.color = addRightArmName.color = addRightArmGold.color = mDisableColor;
//		}
//		if (User.it.rightArmCnt > 0) {
//			addRightArmCnt.text = strCurrent + " x" + User.it.rightArmCnt.ToString("n0");
//			addRightArmName.text = strRightArmUp;
//		} else {
//			addRightArmCnt.text = "";
//			addRightArmName.text = strRightArm;
//		}
//		if (GetRightArmGold () >= double.MaxValue) {
//			addRightArmGold.text = "Max " + strPower;
//		} else {
//			addRightArmGold.text = StringUtil.FormatCash (GetRightArmGold ()) + " " + strPower;
//		}
//
//		if (User.it.goldCnt > GetLeftLegGold ()) {
//			addLeftLeg.color = addLeftLegCnt.color = addLeftLegName.color = addLeftLegGold.color = mEnableColor;
//		} else {
//			addLeftLeg.color = addLeftLegCnt.color = addLeftLegName.color = addLeftLegGold.color = mDisableColor;
//		}
//		if (User.it.leftLegCnt > 0) {
//			addLeftLegCnt.text = strCurrent + " x" + User.it.leftLegCnt.ToString("n0");
//			addLeftLegName.text = strLeftLegUp;
//		} else {
//			addLeftLegCnt.text = "";
//			addLeftLegName.text = strLeftLeg;
//		}
//		if (GetLeftLegGold () >= double.MaxValue) {
//			addLeftLegGold.text = "Max " + strPower;
//		} else {
//			addLeftLegGold.text = StringUtil.FormatCash (GetLeftLegGold ()) + " " + strPower;
//		}
//
//		if (User.it.goldCnt > GetRightLegGold ()) {
//			addRightLeg.color = addRightLegCnt.color = addRightLegName.color = addRightLegGold.color = mEnableColor;
//		} else {
//			addRightLeg.color = addRightLegCnt.color = addRightLegName.color = addRightLegGold.color = mDisableColor;
//		}
//		if (User.it.rightLegCnt > 0) {
//			addRightLegCnt.text = strCurrent + " x" + User.it.rightLegCnt.ToString("n0");
//			addRightLegName.text = strRightLegUp;
//		} else {
//			addRightLegCnt.text = "";
//			addRightLegName.text = strRightLeg;
//		}
//		if (GetRightLegGold () >= double.MaxValue) {
//			addRightLegGold.text = "Max " + strPower;
//		} else {
//			addRightLegGold.text = StringUtil.FormatCash (GetRightLegGold ()) + " " + strPower;
//		}
//
//		adsCnt.text = "";
//		adsName.text = strAdsDesc;
//		adsGold.text = strAdsTitle;
//
//		if (User.it.goldCnt > GetAlphaGoGold ()) {
//			addAlphaGo.color = addAlphaGoCnt.color = addAlphaGoName.color = addAlphaGoGold.color = mEnableColor;
//		} else {
//			addAlphaGo.color = addAlphaGoCnt.color = addAlphaGoName.color = addAlphaGoGold.color = mDisableColor;
//		}
//		addAlphaGoCnt.text = strCurrent + " x" + (User.it.alphaGoCnt+1).ToString("n0");
//		addAlphaGoName.text = strAlphaGo;
//		if (GetAlphaGoGold () >= double.MaxValue) {
//			addAlphaGoGold.text = "Max " + strPower;
//		} else {
//			addAlphaGoGold.text = StringUtil.FormatCash (GetAlphaGoGold ()) + " " + strPower;
//		}
//
//		GameManager.it.UpdateDisplay ();
//		UpdateChar ();
//	}
//
//	// AddCPU
//	public void AddCPU() {
//		if (User.it.goldCnt > GetCPUGold ()) {
//			SoundManager.PlaySFX ("Click");
//			User.it.goldCnt -= GetCPUGold ();
//			User.it.CPUCnt += 1;
//			UpdateDisplay ();
//
//			TalkManager.it.AddCPU ();
//
//			AchievementManager.it.SubmitScore (AchievementManager.LEADERBOARD_ID_ADD_CPU, 
//				User.it.CPUCnt);
//		}
//	}
//
//	// GetCPUGold
//	private double GetCPUGold() {
//		double value = INIT_CPU_GOLD;
//
//		if (User.it.CPUCnt >= 1) {
//			for (int i = 0; i < User.it.CPUCnt; i++) {
//				value *= Mathf.Log (9, 4);
//			}
//		}
//
//		return value;
//	}
//
//	// AddGPU
//	public void AddGPU() {
//		if (User.it.goldCnt > GetGPUGold ()) {
//			SoundManager.PlaySFX ("Click");
//			User.it.goldCnt -= GetGPUGold ();
//			User.it.GPUCnt += 1;
//			UpdateDisplay ();
//
//			TalkManager.it.AddGPU ();
//
//			AchievementManager.it.SubmitScore (AchievementManager.LEADERBOARD_ID_ADD_GPU, 
//				User.it.GPUCnt);
//		}
//	}
//
//	// GetGPUGold
//	private double GetGPUGold() {
//		double value = INIT_GPU_GOLD;
//
//		if (User.it.GPUCnt >= 1) {
//			for (int i = 0; i < User.it.GPUCnt; i++) {
//				value = (value * Mathf.Log (7, 4)) + (value * 0.1);
//			}
//		}
//
//		return value;
//	}
//
//	// AddLeftArm
//	public void AddLeftArm() {
//		if (User.it.goldCnt > GetLeftArmGold ()) {
//			SoundManager.PlaySFX ("Click");
//			User.it.goldCnt -= GetLeftArmGold ();
//			User.it.leftArmCnt += 1;
//			UpdateDisplay ();
//
//			TalkManager.it.AddLeftArm ();
//
//			AchievementManager.it.SubmitScore (AchievementManager.LEADERBOARD_ID_ADD_LEFT_ARM, 
//				User.it.leftArmCnt);
//		}
//	}
//
//	// GetLeftArmGold
//	private double GetLeftArmGold() {
//		double value = INIT_LEFT_ARM_GOLD;
//
//		if (User.it.leftArmCnt >= 1) {
//			for (int i = 0; i < User.it.leftArmCnt; i++) {
//				value *= Mathf.Log (6, 4);
//			}
//		}
//
//		return value;
//	}
//
//	// AddRightArm
//	public void AddRightArm() {
//		if (User.it.goldCnt > GetRightArmGold ()) {
//			SoundManager.PlaySFX ("Click");
//			User.it.goldCnt -= GetRightArmGold ();
//			User.it.rightArmCnt += 1;
//			UpdateDisplay ();
//
//			TalkManager.it.AddRightArm ();
//
//			AchievementManager.it.SubmitScore (AchievementManager.LEADERBOARD_ID_ADD_RIGHT_ARM, 
//				User.it.rightArmCnt);
//		}
//	}
//
//	// GetRightArmGold
//	private double GetRightArmGold() {
//		double value = INIT_RIGHT_ARM_GOLD;
//
//		if (User.it.rightArmCnt >= 1) {
//			for (int i = 0; i < User.it.rightArmCnt; i++) {
//				value = (value * Mathf.Log (6, 4)) + (value * 0.1);
//			}
//		}
//
//		return value;
//	}
//
//	// AddLeftLeg
//	public void AddLeftLeg() {
//		if (User.it.goldCnt > GetLeftLegGold ()) {
//			SoundManager.PlaySFX ("Click");
//			User.it.goldCnt -= GetLeftLegGold ();
//			User.it.leftLegCnt += 1;
//			UpdateDisplay ();
//
//			TalkManager.it.AddLeftLeg ();
//
//			AchievementManager.it.SubmitScore (AchievementManager.LEADERBOARD_ID_ADD_LEFT_LEG, 
//				User.it.leftLegCnt);
//		}
//	}
//
//	// GetLeftLegGold
//	private double GetLeftLegGold() {
//		double value = INIT_LEFT_LEG_GOLD;
//
//		if (User.it.leftLegCnt >= 1) {
//			for (int i = 0; i < User.it.leftLegCnt; i++) {
//				value *= Mathf.Log (7, 4);
//			}
//		}
//
//		return value;
//	}
//
//	// AddRightLeg
//	public void AddRightLeg() {
//		if (User.it.goldCnt > GetRightLegGold ()) {
//			SoundManager.PlaySFX ("Click");
//			User.it.goldCnt -= GetRightLegGold ();
//			User.it.rightLegCnt += 1;
//			UpdateDisplay ();
//
//			TalkManager.it.AddRightLeg ();
//
//			AchievementManager.it.SubmitScore (AchievementManager.LEADERBOARD_ID_ADD_RIGHT_LEG, 
//				User.it.rightLegCnt);
//		}
//	}
//
//	// GetRightLegGold
//	private double GetRightLegGold() {
//		double value = INIT_RIGHT_LEG_GOLD;
//
//		if (User.it.rightLegCnt >= 1) {
//			for (int i = 0; i < User.it.rightLegCnt; i++) {
//				value = (value * Mathf.Log (7, 4)) + (value * 0.1);
//			}
//		}
//
//		return value;
//	}
//
//	// AddAlphaGo
//	public void AddAlphaGo() {
//		if (User.it.goldCnt > GetAlphaGoGold ()) {
//			SoundManager.PlaySFX ("Click");
//			User.it.goldCnt -= GetAlphaGoGold ();
//			User.it.alphaGoCnt += 1;
//			UpdateDisplay ();
//
//			TalkManager.it.AddAlphaGo ();
//
//			AchievementManager.it.SubmitScore (AchievementManager.LEADERBOARD_ID_SAKURA_DROPS, 
//				User.it.alphaGoCnt+1);
//		}
//	}
//
//	// GetAlphaGoGold
//	private double GetAlphaGoGold() {
//		double value = INIT_ALPHAGO_GOLD;
//
//		if (User.it.alphaGoCnt >= 1) {
//			for (int i = 0; i < User.it.alphaGoCnt; i++) {
//				value = value * 2;
//			}
//		}
//
//		return value;
//	}
//}
