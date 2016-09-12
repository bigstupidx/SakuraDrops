using UnityEngine;
using System.Collections;

public class BtnPlay : MonoBehaviour 
{
	ScreenFader fadeScr;

	// Use this for initialization
	void Start () 
	{
		fadeScr = GameObject.FindObjectOfType<ScreenFader>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void OnMouseDown()
	{
		SoundManager.PlaySFX ("Click");
		Application.LoadLevel("game");
	}
}
