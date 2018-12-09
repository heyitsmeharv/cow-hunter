using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	float x, y = 0.0f;
	float touchDiff = 0.2f;
	float mSpeed = 1.0f;
	int rows = 3; 
	int columns = 3;
	private char [,] map;

    GameObject cam;
    LevelLoader Level;

    float rightButton = 550;
    float leftButton = 200;
    float upButton = 189;
    float downButton = 188;

	// Use this for initialization
	void Start () 
	{
        cam = GameObject.Find("Main Camera");
        Level = cam.GetComponent<LevelLoader>();

		map = new char[rows, columns];
		print (rows + " " + columns);

		for(int i = 0; i < columns; i++)
		{
			for(int j = 0; j < rows; j++)
			{
				map[i, j] = 'W';
			}
		}

		print (map [1, 1]);
	}
	
	// Update is called once per frame
	void Update () 
	{
    
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

    public float getXPos()
    {
        return x;
    }


    public float getYPos()
    {
        return y; 
    }

    public void move(int deltaX, int deltaY)
    {
        if(deltaX > 0)
        {
            char tile = Level.getTile((int)transform.position.x + 1, (int)transform.position.y);

            print(tile);

            transform.Translate(tileCheck(tile, deltaX), 0.0f, 0.0f);
        }
        else if(deltaX < 0)
        {
            char tile = Level.getTile((int)transform.position.x - 1, (int)transform.position.y);

            print(tile);

            transform.Translate(tileCheck(tile, deltaX), 0.0f, 0.0f);
        }

        if(deltaY > 0)
        {
            char tile = Level.getTile((int)transform.position.x, (int)transform.position.y + 1);

            print(tile);

            transform.Translate(0.0f, tileCheck(tile, deltaY), 0.0f); 
        }
        else if(deltaY < 0)
        {
            char tile = Level.getTile((int)transform.position.x, (int)transform.position.y - 1);
            
            print(tile);

            transform.Translate(0.0f, tileCheck(tile, deltaY), 0.0f);
        }
    }



}