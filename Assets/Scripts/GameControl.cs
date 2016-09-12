using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour 
{
	private static GameControl m_this;

	public Creator m_cloud;
	public Creator m_wall;
	public Move m_move;
	public HitEffect m_effect;
	public Player m_player;
	public GameObject m_uiEnd;
	public Score m_score;
	public ScoreBoard m_scoreBoard;

	private bool m_playerDead = false;
	

	public static GameControl it()
	{
		return m_this;
	}

	void Awake()
	{
		m_this = this;
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void plusScore()
	{
		if(m_playerDead == false)
			m_score.plus ();
	}

	public void startGame ()
	{
		m_player.start ();
		m_move.start ();
		m_cloud.start ();
		m_wall.start ();
		m_score.gameObject.SetActive (true);
	}

	public void dead()
	{
		m_playerDead = true;

		m_move.moveUp ();
		m_cloud.stop ();
		m_wall.stop ();
		m_effect.hit ();
	}

	public bool isDead()
	{
		return m_playerDead;
	}

	public void gameover()
	{
		AdManager.it.requestInterstitialCount++;

		m_move.stop ();
		m_uiEnd.SetActive (true);
		m_scoreBoard.setScore (User.it.score);
		m_score.gameObject.SetActive (false);
	}
}

