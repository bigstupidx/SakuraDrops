using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public float m_acceleration = 1.0f;

	public ParticleSystem m_particle;

	private float m_speed = 0.0f;
	private bool m_dirRight = true;
	private bool m_dead = false;
	private bool m_start = false;

	private Animator m_animator;

	void Start () 
	{
		m_particle.Stop();
		m_animator = GetComponent<Animator> ();
	}

	void Update () 
	{
		if (m_start == false)
			return;

		if (m_dead == true) {
			GameControl.it().gameover();
			return;
		}

		if (Input.GetMouseButtonDown (0)) 
		{
			turn();
		}
		move ();
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.tag == "enemy")
		{
			dead ();
		}
	}

	public void start()
	{
		User.it.score = 0;

		m_particle.Play();
		m_animator.SetBool ("fly", true);
		StartCoroutine("fly");
	}

	private int moveCount = 15;
	private float moveTrans = 0.015f;
	private IEnumerator fly()
	{
		for(int i=0; i<moveCount; i++)
		{
			transform.Translate(0, moveTrans, 0);
			yield return new WaitForFixedUpdate();
		}
		m_start = true;
		yield return null;
	}

	private IEnumerator fall()
	{
		for(int i=0; i<moveCount; i++)
		{
			transform.Translate(0, -1 * moveTrans, 0);
			yield return new WaitForFixedUpdate();
		}
		yield return null;
	}

	private void move()
	{
		float add = m_acceleration * Time.deltaTime;
		if(m_dirRight == true)
			m_speed += add;
		else
			m_speed -= add;
		
		transform.Translate (m_speed, 0, 0);
	}

	private void turn()
	{
		SoundManager.PlaySFX ("Flap");

		if(m_dirRight == true)
		{
			m_dirRight = false;
		}
		else
		{
			m_dirRight = true;
		}
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	public void dead()
	{	
		if (m_dead == true)
			return;

		m_particle.Stop();

		SoundManager.PlaySFX ("Fall");

		m_dead = true;

		StartCoroutine("fall");
		GameControl.it ().dead ();
	}
}
