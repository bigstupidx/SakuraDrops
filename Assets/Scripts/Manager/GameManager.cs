using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : Singleton<GameManager> {
	void Awake() {
		if (User.it.GetData () == null) {
			Application.targetFrameRate = 60;

			DontDestroyOnLoad (this);
			LanguageCode lang = Language.LanguageNameToCode (Application.systemLanguage);
			Language.SwitchLanguage (lang);

			User.it.LoadData ();
		}
	}

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Escape)){
			string title = "";
			string desc = "";
			string yes = "";
			string no = "";

			switch (Language.CurrentLanguage ()) {
			case LanguageCode.KO:
				title = "알림";
				desc = "종료하시겠습니까?";
				yes = "네";
				no = "아니오";
				break;

			default:
				title = "Notifications";
				desc = "Are you sure you want to quit?";
				yes = "Yes";
				no = "No";
				break;
			}

			MobileNativeDialog dialog = new MobileNativeDialog (title, desc, yes, no);
			dialog.OnComplete += OnDialogClose;
		}
	}

	// OnDialogClose
	private void OnDialogClose(MNDialogResult result) {
		//parsing result
		switch(result) {
		case MNDialogResult.YES:
			User.it.SaveData ();
			Application.Quit();
			break;
		}
	}
}
