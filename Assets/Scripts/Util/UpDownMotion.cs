using UnityEngine;
using System.Collections;

public class UpDownMotion : MonoBehaviour {
	public float Speed = 0.1f;
	public float TransTime = 1.0f;
	float timer = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if(timer < TransTime) {
			transform.Translate(Vector3.down * Speed * Time.deltaTime);
		}
		else if(timer > TransTime) {
			transform.Translate(Vector3.up * Speed * Time.deltaTime);
			
			if(timer > TransTime * 2) {
				timer = 0;
			}
		}
	}
}
