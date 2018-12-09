using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameControllerScript : MonoBehaviour 
{
    int mScore;

    public Text mScoreText;

    int mCowConterVal;

    CowSpawner mCowControl;

	// Use this for initialization
	void Start () 
    {
        mScore = 0;
        mScoreText.text = mScore.ToString();

        mCowControl = GameObject.Find("Spawner").GetComponent<CowSpawner>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void addScore(int val)
    {
        mScore += val;

        mScoreText.text = mScore.ToString();
    }

    public void minusScore(int val) {
        mScore -= val;
        mScoreText.text = mScore.ToString(); 

    }

    public int getScore()
    {
        return mScore;
    }

    public void ReduceCowCount()
    {
        mCowControl.ReduceCounter();
    }
}
