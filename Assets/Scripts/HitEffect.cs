using UnityEngine;
using System.Collections;

public class HitEffect : MonoBehaviour 
{
	private Material m_Material = null;
	// Use this for initialization
	void Start () 
	{
//		m_Material = new Material("Shader \"Plane/No zTest\" { SubShader { Pass { Blend SrcAlpha OneMinusSrcAlpha ZWrite Off Cull Off Fog { Mode Off } BindChannels { Bind \"Color\",color } } } }");
		Shader shader = Shader.Find("Plane/No zTest");
		m_Material = new Material(shader);
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void hit()
	{
		StartCoroutine("twinkling");
		StartCoroutine("shake");
	}

	private void DrawQuad(Color aColor,float aAlpha)
	{
		aColor.a = aAlpha;
		m_Material.SetPass(0);
		GL.Color(aColor);
		GL.PushMatrix();
		GL.LoadOrtho();
		GL.Begin(GL.QUADS);
		GL.Vertex3(0, 0, -1);
		GL.Vertex3(0, 1, -1);
		GL.Vertex3(1, 1, -1);
		GL.Vertex3(1, 0, -1);
		GL.End();
		GL.PopMatrix();
	}

	private IEnumerator twinkling()
	{
		float t = 0.0f;
		float twinklingTime = 0.05f;
		while (t<1.0f)
		{
			yield return new WaitForEndOfFrame();
			t = Mathf.Clamp01(t + Time.deltaTime / twinklingTime);
			DrawQuad(Color.white, 1.0f);
		}

	}

	private IEnumerator shake()
	{
		Vector3 original = transform.position;
		float randRange = 0.05f;
		float wait = 0.01f;
		int size = 7;

		for(int i=0; i<size; i++)
		{
			yield return new WaitForSeconds(wait);
			Vector3 shake = new Vector3();
			shake.x = Random.Range(-1*randRange, randRange);
			shake.y = Random.Range(-1*randRange, randRange);
			transform.position = original + shake;
		}

		transform.position = original;
	}
}
