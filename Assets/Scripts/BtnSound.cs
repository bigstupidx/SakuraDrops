using UnityEngine;
using System.Collections;

public class BtnSound : MonoBehaviour {
	public GameObject imageSoundOn;
	public GameObject imageSoundOff;

	// Use this for initialization
	void Start () {
		SetSound ();	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnMouseDown()
	{
		SoundManager.PlaySFX ("Click");
		User.it.SetSound (!User.it.isSound);
		SetChangeSound ();
	}

	// SetSoundOn
	private void SetSound() {
		if (User.it.isSound) {
			imageSoundOn.SetActive (true);
			imageSoundOff.SetActive (false);
		} else {
			imageSoundOn.SetActive (false);
			imageSoundOff.SetActive (true);
		}
	}

	// SetChangeSound
	public void SetChangeSound() {
		User.it.isSound = !User.it.isSound;

		SetSound ();
	}
}
