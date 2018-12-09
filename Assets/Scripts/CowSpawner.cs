using UnityEngine;
using System.Collections;

public class CowSpawner : MonoBehaviour 
{
    LevelLoader Level;
    public GameObject mCow;

    public int mMaxCowSpawnTime;
    float mCurrentTime;

    public int mMaxCowCounter;
    int mCurrentCowCount;

    Vector3 mSpawnLocation;

    // Use this for initialization
    void Start()
    {
        Level = GameObject.Find("Main Camera").GetComponent<LevelLoader>();
        mCurrentTime = mMaxCowSpawnTime;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (SpawnTimer() && mCurrentCowCount < mMaxCowCounter)
        {
            Instantiate(mCow, mSpawnLocation, Quaternion.identity);
            mCurrentCowCount++;
        }
            
	}

    bool SpawnTimer()
    {
        if (mCurrentTime < 0)
        {
            mCurrentTime = mMaxCowSpawnTime;
            SetPostion();
            return true;
        }
        else
        {
            mCurrentTime -= Time.deltaTime;
            return false;
        }
    }

    void SetPostion()
    {
        int x = Random.Range(0, Level.getMaxX() - 1);
        int y = Random.Range(0, Level.getMaxY() - 1);

        if(Level.CanSpawn(x, y))
        {
            mSpawnLocation = new Vector3(x, y, 0);
        }
        else
        {
            // recalls the function if it was unable to fins open pos
            SetPostion();
        }
    }

    public void ReduceCounter()
    {
        mCurrentCowCount--;
    }


    public int getCounterValue()
    {
        return mCurrentCowCount;
    }
}
