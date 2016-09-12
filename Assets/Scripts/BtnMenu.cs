using UnityEngine;
using System.Collections;

public class BtnMenu : MonoBehaviour 
{
	void Start () 
	{
	
	}

	void Update () 
	{
	
	}

	public void OnMouseDown()
	{
		SoundManager.PlaySFX ("Click");
		Application.LoadLevel("main");
	}
}
