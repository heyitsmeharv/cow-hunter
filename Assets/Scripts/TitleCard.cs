using UnityEngine;
using System.Collections;

public class TitleCard : MonoBehaviour {

    float timer;
    float timerTick;

	// Use this for initialization
	void Start () {

        timer = 0.0f;
        timerTick = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;

        if ((timer >= timerTick) && (transform.position.y > 1.8f))
        {
            transform.Translate(new Vector3(0.0f, -10.0f * Time.deltaTime, 0.0f));
        }
	
	}
}
