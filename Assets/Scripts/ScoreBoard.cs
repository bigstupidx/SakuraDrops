using UnityEngine;
using System.Collections;

public class ScoreBoard : MonoBehaviour 
{
	public GameObject m_new;
	public Score m_score;
	public Score m_best;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void setScore(int score)
	{
		string key = "best";
//		int best = PlayerPrefs.GetInt(key);
		if(User.it.bestScore < score)
		{
			PlayerPrefs.SetInt(key, score);
			User.it.bestScore = score;
			m_new.SetActive(true);
		}
		m_score.setScore (score);
		m_best.setScore (User.it.bestScore);
	}
}
