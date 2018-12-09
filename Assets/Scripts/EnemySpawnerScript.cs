using UnityEngine;
using System.Collections;

public class EnemySpawnerScript : MonoBehaviour 
{
	public Vector3 mSpawnPosition;

	public GameObject mGirlEnemy;
    public GameObject m_MonsterEnemy;

	public float mSpawnDelay;
	float mTimer;

	public int mMaxEnemies;
	int mCurrentEnemiesVal;

	// Use this for initialization
	void Start () 
	{
		mCurrentEnemiesVal = 0;
		transform.position = mSpawnPosition;
		mTimer = mSpawnDelay;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(SpawnTimer() && mCurrentEnemiesVal < mMaxEnemies)
		{
			mCurrentEnemiesVal++;
			Instantiate (mGirlEnemy, mSpawnPosition, Quaternion.identity);
            Instantiate(m_MonsterEnemy, mSpawnPosition, Quaternion.identity);
		}
	}

	bool SpawnTimer()
	{
		if (mTimer < 0) 
		{
			mTimer = mSpawnDelay;
			return true;
		}
		else
		{
			mTimer -= Time.deltaTime;
			return false;
		}

	}
}
