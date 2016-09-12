using UnityEngine;
using System.Collections;

public class BtnAchievement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnMouseDown()
	{
		SoundManager.PlaySFX ("Click");
		AdManager.it.RequestInterstitial ();
	}
}
