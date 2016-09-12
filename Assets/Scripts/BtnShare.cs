using UnityEngine;
using System.Collections;

public class BtnShare : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnMouseDown()
	{
		SoundManager.PlaySFX ("Click");
		ShareMedia.it.Share ();
	}
}
