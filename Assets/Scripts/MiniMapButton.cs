using UnityEngine;
using System.Collections;

public class MiniMapButton : MonoBehaviour 
{
	public Camera mMiniMapCam;
	bool mShow = false;

	// Use this for initialization
	void Start () 
	{
		mMiniMapCam.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void ShowMap()
	{
		if(mShow)
		{
			mMiniMapCam.enabled = mShow;
			mShow = false;
		}
		else
		{
			mMiniMapCam.enabled = mShow;
			mShow = true;
		}
	}
}
