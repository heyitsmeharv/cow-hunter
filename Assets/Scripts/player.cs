using UnityEngine;
using System.Collections;

public class player : MonoBehaviour 
{
    //Vibrator v = (Vibrator)getSystemService(Context.VIBRATOR_SERVICE);

	public enum FacingDirection
	{
		FACING_UP,
		FACING_DOWN,
		FACING_LEFT,
		FACING_RIGHT
	};

	FacingDirection mFacing;

	int rows = 3; 
	int columns = 3;
	private char [,] map;
	
    LevelLoader Level;
    GameControllerScript mControl;
	public GameObject mSpear;

	// Use this for initialization
	void Start () 
	{
		mFacing = FacingDirection.FACING_RIGHT;

		Level = GameObject.Find("Main Camera").GetComponent<LevelLoader>();

        mControl = GameObject.Find("GameControl").GetComponent<GameControllerScript>();

		map = new char[rows, columns];
		//print (rows + " " + columns);

		for(int i = 0; i < columns; i++)
		{
			for(int j = 0; j < rows; j++)
			{
				map[i, j] = 'W';
			}
		}

		//print (map [1, 1]);
	}
	
	// Update is called once per frame
	void Update () 
	{
        print("SCORE : " + mControl.getScore());

        transform.position = new Vector3((int)transform.position.x, (int)transform.position.y, (int)transform.position.z);
    }

	float tileCheck(char tile, int speed)
	{
		switch(tile)
        {
            case 'w': return 0.0f;
            case '0': return speed;
            case '1': return speed;
            case '2': return speed;
            case 'L': return 0.0f;
        }

        return 0.0f;
	}

	public void MoveUP()
	{
		char tile = Level.getTile((int)transform.position.x, (int)transform.position.y + 1);
		
		//print(tile);
		
		transform.Translate (0.0f, tileCheck (tile, 1), 0.0f);

		mFacing = FacingDirection.FACING_UP;

        //Handheld.Vibrate();
	}

	public void MoveDOWN()
	{
		char tile = Level.getTile((int)transform.position.x, (int)transform.position.y - 1);
		
		//print(tile);
		
		transform.Translate (0.0f, tileCheck (tile, -1), 0.0f);

		mFacing = FacingDirection.FACING_DOWN;
        //Handheld.Vibrate();
	}

	public void MoveLEFT()
	{
		char tile = Level.getTile((int)transform.position.x - 1, (int)transform.position.y);
		
		//print(tile);
		
		transform.Translate (tileCheck (tile, -1), 0.0f, 0.0f);
		transform.localScale = new Vector3 (-1, 1, 1);

		mFacing = FacingDirection.FACING_LEFT;

        //Handheld.Vibrate();
	}

	public void MoveRIGHT()
	{
		char tile = Level.getTile((int)transform.position.x + 1, (int)transform.position.y);
		
		//print(tile);
		
		transform.Translate (tileCheck (tile, 1), 0.0f, 0.0f);
		transform.localScale = new Vector3 (1, 1, 1);

		mFacing = FacingDirection.FACING_RIGHT;

        //Handheld.Vibrate();
	}

	public void ThrowSpear()
	{
        Vector3 firePosUP = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        Vector3 firePosDOWN = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
        Vector3 firePosLEFT = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        Vector3 firePosRIGHT = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);

		switch (mFacing) 
		{
            case FacingDirection.FACING_UP: Instantiate(mSpear, firePosUP, Quaternion.AngleAxis(90.0f, Vector3.forward)); break;
            case FacingDirection.FACING_DOWN: Instantiate(mSpear, firePosDOWN, Quaternion.AngleAxis(-90.0f, Vector3.forward)); break;
            case FacingDirection.FACING_LEFT: Instantiate(mSpear, firePosLEFT, Quaternion.AngleAxis(180.0f, Vector3.up)); break;
            case FacingDirection.FACING_RIGHT: Instantiate(mSpear, firePosRIGHT, Quaternion.AngleAxis(0, Vector3.up)); break;
		}

	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Cow")
        {
            mControl.ReduceCowCount();
            print("HIT COW");
            mControl.addScore(10);
            Destroy(col.gameObject);
        }
            
    }

    //public void move(int deltaX, int deltaY)
    //{
    //    if(deltaX > 0)
    //    {
    //        char tile = Level.getTile((int)transform.position.x + 1, (int)transform.position.y);

    //        print(tile);

    //        transform.Translate(tileCheck(tile, deltaX), 0.0f, 0.0f);
    //    }
    //    else if(deltaX < 0)
    //    {
    //        char tile = Level.getTile((int)transform.position.x - 1, (int)transform.position.y);

    //        print(tile);

    //        transform.Translate(tileCheck(tile, deltaX), 0.0f, 0.0f);
    //    }

    //    if(deltaY > 0)
    //    {
    //        char tile = Level.getTile((int)transform.position.x, (int)transform.position.y + 1);

    //        print(tile);

    //        transform.Translate(0.0f, tileCheck(tile, deltaY), 0.0f); 
    //    }
    //    else if(deltaY < 0)
    //    {
    //        char tile = Level.getTile((int)transform.position.x, (int)transform.position.y - 1);
            
    //        print(tile);

    //        transform.Translate(0.0f, tileCheck(tile, deltaY), 0.0f);
    //    }
    //}
}