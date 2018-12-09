using UnityEngine;
using System.Collections;

public class MonsterAIScript : MonoBehaviour {

    public float timerTick; 

    LevelLoader m_Level;                // Accessing Level Variables
    player m_Player;                    // Accessing Player Variables
    GameObject m_Cow;                    // Accessing Cow Variable
    GameControllerScript m_Control;     // Score

    private float movementCD = 0.5f;
    private float viewDistance = 3.0f;

    // Movement States
    public enum MovementState {
        PATROL_UP_STATE,
        PATROL_DOWN_STATE,
        PATROL_LEFT_STATE,
        PATROL_RIGHT_STATE,

        NUMOFPATROLSTATES,

        CHASE_STATE = NUMOFPATROLSTATES

    };

    public MovementState mState;
    public int mMoveSpeed;  


	// Use this for initialization
	void Start () {
        timerTick = 5.0f;
        m_Level = GameObject.Find("Main Camera").GetComponent<LevelLoader>();               // Level Obj
        m_Player = GameObject.Find("CaveMan").GetComponent<player>();                       // Player Obj
        m_Cow = GameObject.Find("Cow(Clone)");                                                   // Cow Obj
        m_Control = GameObject.Find("GameControl").GetComponent<GameControllerScript>();     // Score

        ChoosePatrolState();
	}
	
	// Update is called once per frame
	void Update () {
        //distanceCheck();
        timerTick -= Time.deltaTime;

        if (timerTick <= 0.0f)
        {
            int temp = Random.Range(0, 4);

            mState = (MovementState)temp;

            timerTick = 5.0f;

            print(mState);
        }

        if (movementCD <= 0)
        {
            movementCD = 0.5f;

            switch (mState)
            {
                case MovementState.PATROL_UP_STATE: PatrolUp(); break;
                case MovementState.PATROL_DOWN_STATE: PatrolDown(); break;
                case MovementState.PATROL_LEFT_STATE: PatrolLeft(); break;
                case MovementState.PATROL_RIGHT_STATE: PatrolRight(); break;
                //case MovementState.CHASE_STATE: Chase(); break;

                default: break;
            }
        }
        else
        {
            movementCD -= Time.deltaTime;
        }
	}

    void PatrolUp()
    {
        char tile = m_Level.getTile((int)transform.position.x, (int)transform.position.y + 1);

        //print(tile);

        transform.Translate(0.0f, tileCheck(tile, 1), 0.0f);
    }

    void PatrolDown()
    {
        char tile = m_Level.getTile((int)transform.position.x, (int)transform.position.y - 1);

        //print(tile);

        transform.Translate(0.0f, tileCheck(tile, -1), 0.0f);
    }

    void PatrolLeft()
    {
        char tile = m_Level.getTile((int)transform.position.x - 1, (int)transform.position.y);

        //print(tile);

        transform.Translate(tileCheck(tile, -1), 0.0f, 0.0f);
    }
    void PatrolRight()
    {
        char tile = m_Level.getTile((int)transform.position.x + 1, (int)transform.position.y);

        //print(tile);

        transform.Translate(tileCheck(tile, 1), 0.0f, 0.0f);
    }

    void ChoosePatrolState()
    {
        mState = (MovementState)Random.Range(0, (int)MovementState.NUMOFPATROLSTATES);
    }

    float tileCheck(char tile, int speed)
    {
        switch (tile)
        {
            case 'w': ChoosePatrolState(); return 0.0f;
            case '0': return speed;
            case '1': return speed;
            case '2': return speed;
            case 'L': return speed; 
        }

        return 0.0f;
    }


    // Collision Detection.
    // Delete the Cow on collision, lower the players score. 
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "CaveMan") {
            //m_Control.ReduceCowCount();
            print("PLAYER DEAD");
            //m_Control.minusScore(10); 
            Destroy(collision.gameObject); 
        }
    }
}
