using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {

	public bool startGame = false;
	//public float m_time; 
	//public float m_lastTime;
	//public float m_delta;

	public bool m_mouseOver;
	public float m_scale;
	//public float m_timeCounter;
	//public const float timePerFrame = 1.0f;

    float timer;
    float timerTick;

	// Use this for initialization
	void Start () {

		m_scale = 1.0f;

        timer = 0.0f;
        timerTick = 1.0f;

		//m_time = Time.time;
		//m_lastTime = m_time;

		//m_time = clock();
		//m_lastTime = m_time;
	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;

        if ((timer >= timerTick) && (transform.position.y < -4.0f))
        {
            transform.Translate(new Vector3(0.0f, +10.0f * Time.deltaTime, 0.0f));
        }


		if (m_mouseOver && Input.GetMouseButton(0))
		{
			if(m_scale < 1.2f)
			{
				m_scale += 0.05f;
				transform.localScale = new Vector3(m_scale, m_scale, transform.localScale.z);
			}
		}
		else
		{
			if(m_scale > 1.0f)
			{
				m_scale -= 0.05f;
				transform.localScale = new Vector3(m_scale, m_scale, transform.localScale.z);
			}
		}

		if(m_mouseOver && Input.GetMouseButtonUp(0))
		{
			startGame = true;
			Application.LoadLevel(1);
		}
	}
		void OnMouseOver()
		{
			print ("Mouse is over");

			if(Input.GetMouseButtonDown(0))
			{
				m_mouseOver = true;
		 	}
		}

		void OnMouseExit()
		{
			print ("!Mouse is over");
			
			m_mouseOver = false;

		}
}
