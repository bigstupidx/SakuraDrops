using UnityEngine;
using System.Collections;

public class ShareMedia : Singleton<ShareMedia> {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// ShareMedia
	public void Share() {
		StartCoroutine(PostScreenshot());
	}

	// PostScreenshot
	private IEnumerator PostScreenshot() {
		yield return new WaitForEndOfFrame();
		string title = "";
		string desc = "";

		switch (Language.CurrentLanguage()) {
		case LanguageCode.KO:
			title = "벚꽃엔딩";
			desc = "❀✺따뜻한 봄을 간직한 벚꽃이 피었어요.❀✺";
			break;

		case LanguageCode.JA:
			title = "さくらドロップス";
			desc = "❀✺暖かい春を秘め桜が血だった.❀✺";
			break;

		default:
			title = "Sakura Drops";
			desc = "❀✺ was bearing the warm spring blooming cherry .❀✺";
			break;
		}

		// Create a texture the size of the screen, RGB24 format
		int width = Screen.width;
		int height = Screen.height;
		Texture2D tex = new Texture2D( width, height, TextureFormat.RGB24, false );
		// Read screen contents into the texture
		tex.ReadPixels( new Rect(0, 0, width, height), 0, 0 );
		tex.Apply();

		UM_ShareUtility.ShareMedia(title, desc, tex);

		Destroy(tex);
	}
}
