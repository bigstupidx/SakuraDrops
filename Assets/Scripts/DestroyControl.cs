using UnityEngine;
using System.Collections;

public class DestroyControl : MonoBehaviour 
{
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.tag == "floor") 
		{
			if(GameControl.it().isDead() == false)
				other.gameObject.transform.parent = null;
		} 
		else 
		{
			Destroy (other.gameObject);	
		}
	}
}
