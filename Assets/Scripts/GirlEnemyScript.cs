using UnityEngine;
using System.Collections;

public class GirlEnemyScript : MonoBehaviour
{
    LevelLoader Level;
    player player;
    GameControllerScript controller;

    private float movementCD = 1.0f;
    private float viewDistance = 3.0f;

    int numOfHighscores = 10;

    public enum MovementState
    {
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
    void Start()
    {
        Level = GameObject.Find("Main Camera").GetComponent<LevelLoader>();
        player = GameObject.Find("CaveMan").GetComponent<player>();
        controller = GameObject.Find("GameControl").GetComponent<GameControllerScript>();

        ChoosePatrolState();
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerPrefs.DeleteAll();

        distanceCheck();

        if (movementCD <= 0)
        {
            movementCD = 1.0f;

            switch (mState)
            {
                case MovementState.PATROL_UP_STATE: PatrolUp(); break;
                case MovementState.PATROL_DOWN_STATE: PatrolDown(); break;
                case MovementState.PATROL_LEFT_STATE: PatrolLeft(); break;
                case MovementState.PATROL_RIGHT_STATE: PatrolRight(); break;
                case MovementState.CHASE_STATE: Chase(); break;

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
        char tile = Level.getTile((int)transform.position.x, (int)transform.position.y + 1);

        //print(tile);

        transform.Translate(0.0f, tileCheck(tile, 1), 0.0f);
    }

    void PatrolDown()
    {
        char tile = Level.getTile((int)transform.position.x, (int)transform.position.y - 1);

        //print(tile);

        transform.Translate(0.0f, tileCheck(tile, -1), 0.0f);
    }

    void PatrolLeft()
    {
        char tile = Level.getTile((int)transform.position.x - 1, (int)transform.position.y);

        //print(tile);

        transform.Translate(tileCheck(tile, -1), 0.0f, 0.0f);
    }
    void PatrolRight()
    {
        char tile = Level.getTile((int)transform.position.x + 1, (int)transform.position.y);

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
            case 'L': ChoosePatrolState(); return 0.0f;
        }

        return 0.0f;
    }

    void distanceCheck()
    {
        float distance = Mathf.Pow(Mathf.Pow((transform.position.x - player.transform.position.x), 2) +
            Mathf.Pow((transform.position.y - player.transform.position.y), 2), 0.5f);

        if (distance <= viewDistance)
            mState = MovementState.CHASE_STATE;

        if (distance == 0)
        {
            //CheckHighscore();
            Application.LoadLevel(2);
        }
    }
    void Chase()
    {
        if (player.transform.position.x > transform.position.x)
        {
            PatrolRight();
        }

        else if (player.transform.position.x < transform.position.x)
        {
            PatrolLeft();
        }

        if (player.transform.position.y > transform.position.y)
        {
            PatrolUp();
        }
        else if (player.transform.position.y < transform.position.y)
        {
            PatrolDown();
        }

    }

    //void CheckHighscore()
    //{
    //    int place = 0;

    //    if (controller.getScore() > PlayerPrefs.GetInt("highscore" + (numOfHighscores - 1), 0))
    //    {
    //        for (int i = 0; i < numOfHighscores; i++)
    //        {
    //            if (controller.getScore() > PlayerPrefs.GetInt("highscore" + i, 0))
    //            {
    //                if (i == 0)
    //                    place = 0;
    //                else
    //                    place = i - 1;

    //                print("PLACE = " + place);

    //                for (int j = numOfHighscores - 1; j > place; j--)
    //                {
    //                    PlayerPrefs.SetInt("highscore" + j, PlayerPrefs.GetInt("highscore" + (j - 1)));
    //                }

    //                break;
    //            }
    //        }
    //    }

    //    PlayerPrefs.SetInt("highscore" + place, controller.getScore());

    //    //for (int i = 0; i < numOfHighscores; i++)
    //    //{
    //    //    print(i + " : " + PlayerPrefs.GetInt("highscore" + i));
    //    //}
    //}
}