using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour 
{
	public GameObject m_number;

	private ArrayList m_list = new ArrayList();
	private int m_max = 5;
	void Start () 
	{
		make ();
		setScore (0);
	}
	void Update () 
	{
	
	}
	private void make()
	{
		for(int i=0; i < m_max; i++)
		{
			GameObject number = Instantiate(m_number) as GameObject;
			Vector3 pos = number.transform.position;
			float size = number.GetComponent<Renderer>().bounds.size.x;
			pos.x = transform.position.x - size * m_max + number.GetComponent<Renderer>().bounds.size.x * (i+1);
			pos.y = transform.position.y;
			pos.z = -5.0f;
			number.transform.position = pos;
			number.transform.parent = transform;
			m_list.Add(number.GetComponent<SpriteNumber>());
		}
	}

	public void plus()
	{
		SoundManager.PlaySFX ("Score");
		User.it.score++;
		setScore (User.it.score);
	}

	public void setScore(int score)
	{
		if (score < 0)
			return;
		
		char[] nums = score.ToString ().ToCharArray ();
		int numCount = 0;
		int numSize = nums.Length;
		int remain = m_max - numSize;

		for(int i=0; i<m_list.Count; i++)
		{
			SpriteNumber number = m_list[i] as SpriteNumber;
			if(remain <= i)
			{
				number.setNumber(int.Parse(nums[numCount].ToString()));
				numCount++;
			}
			else
			{
				number.erase();
			}
		}
	}
}
