using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour 
{
	public float m_downSpeed = -1.0f;
	private bool m_down = true;
	private bool m_move = false;

	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (m_move == false)
			return;
		
		transform.Translate (0, m_downSpeed * Time.deltaTime, 0);
	}

	public void moveUp()
	{
		m_down = false;
	}

	public void start()
	{
		m_move = true;
	}

	public void stop()
	{
		m_move = false;
	}
}
