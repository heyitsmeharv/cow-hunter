﻿using UnityEngine;
using System.Collections;

public class SpearScript : MonoBehaviour 
{
    public float mSpeed;

	// Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.Translate(Vector3.right * mSpeed);
	}
}
