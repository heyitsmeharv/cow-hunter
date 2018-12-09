using UnityEngine;
using System.Collections;

public class TitleCow : MonoBehaviour {

    public enum facingDirection
    {
        F_LEFT,
        F_RIGHT
    };

    public facingDirection m_facing;

	// Use this for initialization
	void Start () {

        if(transform.position.x > 0)
        {
            m_facing = facingDirection.F_LEFT;
        }
        else
        {
            m_facing = facingDirection.F_RIGHT;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if ((transform.position.x >= 10.0f) || (transform.position.x <= -10.0f))
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }

        switch (m_facing)
        {
            case facingDirection.F_LEFT:
                {
                    transform.position = new Vector3(transform.position.x - 0.5f * Time.deltaTime, transform.position.y, transform.position.z);

                    if (transform.position.x <= -10.0f)
                    {
                        m_facing = facingDirection.F_RIGHT;
                    }
                }
                break;

            case facingDirection.F_RIGHT:
                {
                    transform.position = new Vector3(transform.position.x + 0.5f * Time.deltaTime, transform.position.y, transform.position.z);

                    if (transform.position.x >= 10.0f)
                    {
                        m_facing = facingDirection.F_LEFT;
                    }
                }
                break;
        }
	}
}
