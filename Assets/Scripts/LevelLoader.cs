using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

    public GameObject WallTile;
    public GameObject GrassTile0;
    public GameObject GrassTile1;
    public GameObject GrassTile2;
    public GameObject WaterTile;

	int rowsize = 20;
	int colsize = 32;


	char[,] selectedLevel = new char[20, 32];

	char[,] Level0 = new char[20, 32] {	{ 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w'}, 
										{ 'w', '0', '1', '2', '0', '1', '2', '0', '1', '0', '1', '2', '0', '1', '2', '0', '1', '0', '1', '2', '0', '1', '2', '0', '1', '0', '1', '2', '0', '1', '2', 'w'}, 
										{ 'w', '2', '1', '1', '1', '0', '0', '1', '2', '0', '1', '2', '2', '1', '2', '0', '1', '0', '1', '2', '0', '1', '2', '0', '1', '0', '1', '2', '0', '1', '2', 'w'}, 
										{ 'w', '1', '2', '0', '1', '2', '0', '1', '1', '1', '1', '2', '0', '1', '1', '1', '2', '0', '1', '2', '0', '1', '2', '0', '1', '0', '1', '2', '0', '1', '2', 'w'}, 
										{ 'w', '1', '2', '2', '1', '0', '0', '1', '2', '2', '0', '1', '2', '1', '2', '0', '1', '0', '1', '2', '0', '1', '2', '0', '1', '0', '1', '2', '0', '1', '2', 'w'},  
										{ 'w', '1', '0', '2', '2', '1', '2', '0', '0', '1', '1', '2', '0', '2', '2', '1', '1', '0', '1', '2', '0', '1', '2', '0', '1', '0', '1', '2', '0', '1', '2', 'w'}, 
										{ 'w', '0', '0', '1', '0', '2', '0', '1', '1', '0', '1', '2', '0', '1', '0', '0', '0', '0', '1', '2', '0', '1', '2', '0', '1', '0', '1', '2', '0', '1', '2', 'w'},  
										{ 'w', '1', '2', '2', '0', '1', '1', '0', '1', '1', '1', '2', '2', '1', '2', '0', '1', '0', '1', '2', '0', '1', '2', '0', '1', '0', '1', '2', '0', '1', '2', 'w'},   
										{ 'w', '2', '0', '0', '1', '0', '1', '2', '1', '2', '1', '2', '0', '1', '2', '0', '1', '0', '1', '2', '0', '1', '2', '0', '1', '0', '1', '2', '0', '1', '2', 'w'}, 
										{ 'w', '0', '1', '2', '0', '1', '2', '0', '1', '0', '1', '2', '0', '1', '2', '0', '1', '0', '1', '2', '0', '1', '2', '0', '1', '0', '1', '2', '0', '1', '2', 'w'}, 
										{ 'w', '2', '1', '1', '1', '0', '0', '1', '2', '0', '1', '2', '2', '1', '2', '0', '1', '0', '1', '2', '0', '1', '2', '0', '1', '0', '1', '2', '0', '1', '2', 'w'}, 
										{ 'w', '1', '2', '0', '1', '2', '0', '1', '1', '1', '1', '2', '0', '1', '1', '1', '2', '0', '1', '2', '0', '1', '2', '0', '1', '0', '1', '2', '0', '1', '2', 'w'}, 
										{ 'w', '1', '2', '2', '1', '0', '0', '1', '2', '2', '0', '1', '2', '1', '2', '0', '1', '0', '1', '2', '0', '1', '2', '0', '1', '0', '1', '2', '0', '1', '2', 'w'},  
										{ 'w', '1', '0', '2', '2', '1', '2', '0', '0', '1', '1', '2', '0', '2', '2', '1', '1', '0', '1', '2', '0', '1', '2', '0', '1', '0', '1', '2', '0', '1', '2', 'w'}, 
										{ 'w', '0', '0', '1', '0', '2', '0', '1', '1', '0', '1', '2', '0', '1', '0', '0', '0', '0', '1', '2', '0', '1', '2', '0', '1', '0', '1', '2', '0', '1', '2', 'w'},  
										{ 'w', '1', '2', '2', '0', '1', '1', '0', '1', '1', '1', '2', '2', '1', '2', '0', '1', '0', '1', '2', '0', '1', '2', '0', '1', '0', '1', '2', '0', '1', '2', 'w'},   
										{ 'w', '2', '0', '0', '1', '0', '1', '2', '1', '2', '1', '2', '0', '1', '2', '0', '1', '0', '1', '2', '0', '1', '2', '0', '1', '0', '1', '2', '0', '1', '2', 'w'}, 
										{ 'w', '1', '2', '2', '0', '1', '1', '0', '1', '1', '1', '2', '2', '1', '2', '0', '1', '0', '1', '2', '0', '1', '2', '0', '1', '0', '1', '2', '0', '1', '2', 'w'},   
										{ 'w', '2', '0', '0', '1', '0', '1', '2', '1', '2', '1', '2', '0', '1', '2', '0', '1', '0', '1', '2', '0', '1', '2', '0', '1', '0', '1', '2', '0', '1', '2', 'w'}, 
										{ 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w'} };



	// Use this for initialization
	void Start () {

        //pick random number
        int tempRand = Random.Range(0, 1);

        //pick random level with number
        switch(tempRand)
        {
            case 0: selectedLevel = Level0; break;
           // case 1: selectedLevel = Level1; break;
           // case 2: selectedLevel = Level2; break;

        }
        

		for(int row = 0; row < rowsize; row++)
        {
			for (int column = 0; column < colsize; column++)
            {
                switch (selectedLevel[row, column])
                {
                    case 'w' : 

                        //build wall
                        Instantiate(WallTile, new Vector3(column, row, 0), Quaternion.identity);

                        break;

                    case '0':

                        //build wall
                        Instantiate(GrassTile0, new Vector3(column, row, 0), Quaternion.identity);

                        break;

                    case '1':

                        //build wall
                        Instantiate(GrassTile1, new Vector3(column, row, 0), Quaternion.identity);

                        break;

                    case '2':

                        //build wall
                        Instantiate(GrassTile2, new Vector3(column, row, 0), Quaternion.identity);

                        break;

                    case 'L':

                        //build wall
                        Instantiate(WaterTile, new Vector3(column, row, 0), Quaternion.identity);

                        break;
                }

            }
        }

	}

    public char getTile(int xPos, int yPos)
    {
        //print("get tile: " + yPos + ", " + xPos);
        //print("get tile: " + selectedLevel[yPos, xPos]);

        return selectedLevel[yPos, xPos];
    }

    public bool CanSpawn(int x, int y)
    {
        if (getTile(x, y) == 'w' || getTile(x, y) == 'L')
            return false;
        else
            return true;
    }

    public int getMaxY()
    {
        return rowsize;
    }

    public int getMaxX()
    {
        return colsize;
    }
}
