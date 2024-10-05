using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    public GameObject tilecube;
    public Material roadMaterial;
    public int worldSize = 10;

    public GameObject tinyGuyPrefab;

    // 2d array to store the grid of cubes
    private GameObject[,] grid;

    // Start is called before the first frame update
    void Start()
    {

        //initialize the grid
        grid = new GameObject[worldSize, worldSize];

        //generate a 10x10 grid of cubes
        for (int x = -(worldSize/2); x < worldSize/2; x++)
        {
            for (int z = -(worldSize/2); z < worldSize/2; z++)
            {
                GameObject newCube = Instantiate(tilecube);
                newCube.transform.position = new Vector3(x, 0, z);
                // scale the cube on y axis to create a randomly sized tower
                newCube.transform.localScale = new Vector3(1, Random.Range(1, 4), 1);

                // store the cube in the grid
                grid[x + worldSize/2, z + worldSize/2] = newCube;
            }
        }



        for(int n = 0; n < Mathf.RoundToInt(worldSize/worldSize)+5; n++){
            //pick a random starting point
            int currentX = Random.Range(0, worldSize);
            int currentZ = Random.Range(0, worldSize);

            int lastDirection = 0;

            //create a road from the starting point, moving in a random direction each time
            for (int i = 0; i < 100; i++)
            {
                // disable the cube's renderer
                grid[currentX, currentZ].GetComponent<Renderer>().material = roadMaterial;

                // set height to 0.1f
                grid[currentX, currentZ].transform.localScale = new Vector3(1, 0.1f, 1);

                // instantiate a tiny guy at the current position
                GameObject tinyGuy = Instantiate(tinyGuyPrefab);
                tinyGuy.transform.position = new Vector3(currentX/2, 0.5f, currentZ/2);

                //move in a random direction, but prefer to move in the same direction as the last move
                int chanceOfSameDirection = 80;
                if (Random.Range(0, 100) < chanceOfSameDirection)
                {
                    //keep moving in the same direction
                }
                else
                {
                    //pick a new direction
                    lastDirection = Random.Range(0, 4);
                }

                //move in the direction
                if (lastDirection == 0)
                {
                    currentX++;
                }
                else if (lastDirection == 1)
                {
                    currentX--;
                }
                else if (lastDirection == 2)
                {
                    currentZ++;
                }
                else if (lastDirection == 3)
                {
                    currentZ--;
                }

                //make sure the new position is within the grid
                currentX = Mathf.Clamp(currentX, 0, worldSize - 1);
                currentZ = Mathf.Clamp(currentZ, 0, worldSize - 1);

                

            }


        }
        

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
