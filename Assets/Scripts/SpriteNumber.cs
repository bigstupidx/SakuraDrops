using UnityEngine;
using System.Collections;

public class SpriteNumber : MonoBehaviour 
{
	public Sprite[] m_number;
	void Start () 
	{
	
	}

	void Update () 
	{
	
	}

	public void setNumber(int number)
	{
		gameObject.GetComponent<SpriteRenderer>().sprite = m_number[number];
	}

	public void erase()
	{
		gameObject.GetComponent<SpriteRenderer>().sprite = null;
	}
}
