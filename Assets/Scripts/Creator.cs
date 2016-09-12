using UnityEngine;
using System.Collections;

public class Creator : MonoBehaviour 
{
	public float m_wait = 1.0f;
	public GameObject m_object;
	public Transform m_left;
	public Transform m_right;
	public Transform m_parent;
	public float m_depth = 0;

	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void start()
	{
		StartCoroutine("create");
	}

	public void stop()
	{
		StopCoroutine("create");
	}

	private IEnumerator create()
	{
		while (true) 
		{
			Vector3 pos = new Vector3();
			pos.x = Random.Range(m_left.position.x, m_right.position.x);
			pos.y = m_left.position.y;
			pos.z = m_depth;

			GameObject gameobject = Instantiate(m_object) as GameObject;
			gameobject.transform.position = pos;
			gameobject.transform.parent = m_parent.transform;

			yield return new WaitForSeconds(m_wait);
		}
	}
}
