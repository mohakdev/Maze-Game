using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    // Variables
    public GameObject WallSample;
    public GameObject FloorSample;

    public int Rows = 10;
    public int Coloumns = 10;

    MazeCellScript[,] grid;
    int CurrentRow = 0;
    int CurrentColoumn = 0;

    //Start Method
    void Start()
    {
        CreateGrid();
        HuntAndKill();
    }

    void CreateGrid()
    {
        grid = new MazeCellScript[Rows, Coloumns];
        float size = FloorSample.transform.localScale.x;
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Coloumns; j++)
            {

                // We are looping through all coloums and rows and making floor grid
                GameObject floor = Instantiate(FloorSample, new Vector3(j * size, 0, -i * size), Quaternion.identity);
                floor.name = $"Floor_{i}_{j}";
                //Now making the walls
                GameObject UpWall = Instantiate(WallSample,
                new Vector3(j * size, 5.25f, -i * size + 4.75f), Quaternion.identity);
                UpWall.name = $"UpWall_{i}_{j}";
                //------------------------------------
                GameObject DownWall = Instantiate(WallSample,
                new Vector3(j * size, 5.25f, -i * size - 4.75f), Quaternion.identity);
                DownWall.name = $"DownWall_{i}_{j}";
                //------------------------------------
                GameObject LeftWall = Instantiate(WallSample,
                new Vector3(j * size - 4.75f, 5.25f, -i * size), Quaternion.Euler(0, 90, 0));
                LeftWall.name = $"LeftWall_{i}_{j}";
                //------------------------------------
                GameObject RightWall = Instantiate(WallSample,
                new Vector3(j * size + 4.75f, 5.25f, -i * size), Quaternion.Euler(0, 90, 0));
                RightWall.name = $"RightWall_{i}_{j}";
                //------------------------------------
                grid[i, j] = new MazeCellScript
                {
                    UpWall = UpWall,
                    downWall = DownWall,
                    LeftWall = LeftWall,
                    RightWall = RightWall
                };
                //Now setting all of them inside a single parent
                floor.transform.SetParent(transform);
                LeftWall.transform.SetParent(transform);
                RightWall.transform.SetParent(transform);
                UpWall.transform.SetParent(transform);
                DownWall.transform.SetParent(transform);
            }
        }
    }
    void HuntAndKill()
    {
        while (UnvisitedNeighbors())
        {
            grid[CurrentRow, CurrentColoumn].isVisited = true;

            Walk();
            //Hunt();
        }
    }


    void Walk()
    {
        int direction = Random.Range(0, 4);
        //Looks Up
        if (direction == 0)
        {
            if (IsCellUnVisited(CurrentRow - 1, CurrentColoumn))
            {
                if (grid[CurrentRow, CurrentColoumn].UpWall)
                {
                    Destroy(grid[CurrentRow, CurrentColoumn].UpWall);
                }
                CurrentRow--;
                grid[CurrentRow, CurrentColoumn].isVisited = true;
                if (grid[CurrentRow, CurrentColoumn].downWall)
                {
                    Destroy(grid[CurrentRow, CurrentColoumn].downWall);
                }
            }
        }
        // Looks Down
        else if (direction == 1)
        {
            if (IsCellUnVisited(CurrentRow + 1, CurrentColoumn))
            {
                if (grid[CurrentRow, CurrentColoumn].downWall)
                {
                    Destroy(grid[CurrentRow, CurrentColoumn].downWall);
                }
                CurrentRow++;
                grid[CurrentRow, CurrentColoumn].isVisited = true;
                if (grid[CurrentRow, CurrentColoumn].UpWall)
                {
                    Destroy(grid[CurrentRow, CurrentColoumn].UpWall);
                }
            }
        }
        //Looks Left
        else if (direction == 2)
        {
            if (IsCellUnVisited(CurrentRow, CurrentColoumn - 1))
            {
                if (grid[CurrentRow, CurrentColoumn].LeftWall)
                {
                    Destroy(grid[CurrentRow, CurrentColoumn].LeftWall);
                }
                CurrentColoumn--;
                grid[CurrentRow, CurrentColoumn].isVisited = true;
                if (grid[CurrentRow, CurrentColoumn].RightWall)
                {
                    Destroy(grid[CurrentRow, CurrentColoumn].RightWall);
                }
            }
        }
        //Looks Right
        else if (direction == 3)
        {
            if (IsCellUnVisited(CurrentRow, CurrentColoumn + 1))
            {
                if (grid[CurrentRow, CurrentColoumn].RightWall)
                {
                    Destroy(grid[CurrentRow, CurrentColoumn].RightWall);
                }
                CurrentColoumn++;
                grid[CurrentRow, CurrentColoumn].isVisited = true;
                if (grid[CurrentRow, CurrentColoumn].LeftWall)
                {
                    Destroy(grid[CurrentRow, CurrentColoumn].LeftWall);
                }
            }
        }
    }
    void Hunt()
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Coloumns; j++)
            {
                //Scanning the grid
                if (!grid[i, j].isVisited && VisitedNeighbors(i, j))
                {
                    CurrentRow = i;
                    CurrentColoumn = j;
                    grid[CurrentRow, CurrentColoumn].isVisited = true;
                    DestroyAdjacentWall();
                    return;
                }
            }
        }
    }

    private void DestroyAdjacentWall()
    {
        bool Destroyed = false;
        while (!Destroyed)
        {
            int direction = Random.Range(0, 4);
            //check up
            if (direction == 0)
            {
                if (CurrentRow > 0 && grid[CurrentRow - 1, CurrentColoumn].isVisited)
                {
                    Destroy(grid[CurrentRow - 1, CurrentColoumn].downWall);
                    Destroyed = true;
                }
            }
            // check down
            else if (direction == 1)
            {
                if (CurrentRow < Rows - 1 && grid[CurrentRow + 1, CurrentColoumn].isVisited)
                {
                    Destroy(grid[CurrentRow + 1, CurrentColoumn].UpWall);
                    Destroyed = true;
                }
            }
            //check left
            else if (direction == 2)
            {
                if (CurrentColoumn > 0 && grid[CurrentRow, CurrentColoumn - 1].isVisited)
                {
                    Destroy(grid[CurrentRow, CurrentColoumn - 1].RightWall);
                    Destroyed = true;
                }
            }
            //check right
            else if (direction == 3)
            {
                if (CurrentColoumn < Coloumns - 1 && grid[CurrentRow, CurrentColoumn + 1].isVisited)
                {
                    Destroy(grid[CurrentRow, CurrentColoumn + 1].LeftWall);
                    Destroyed = true;
                }
            }
        }
    }

    private bool UnvisitedNeighbors()
    {
        //check up for unvisited neighbors
        if (IsCellUnVisited(CurrentRow - 1, CurrentColoumn))
        {
            return true;
        }
        //check down for unvisited neighbors
        if (IsCellUnVisited(CurrentRow + 1, CurrentColoumn))
        {
            return true;
        }
        //check left for unvisited neighbors
        if (IsCellUnVisited(CurrentRow, CurrentColoumn + 1))
        {
            return true;
        }
        //check up for unvisited neighbors
        if (IsCellUnVisited(CurrentRow, CurrentColoumn - 1))
        {
            return true;
        }
        return false;
    }
    //Doing a boundary check and unvisited check
    private bool IsCellUnVisited(int row, int col)
    {
        if (row >= 0 && row < Rows && col >= 0 && col < Coloumns && !grid[row, col].isVisited)
        {
            return true;
        }
        return false;
    }
    public bool VisitedNeighbors(int row, int col)
    {
        //check up
        if (row > 0 && grid[row - 1, col].isVisited)
        {
            return true;
        }
        //check down
        if (row < Rows - 1 && grid[row + 1, col].isVisited)
        {
            return true;
        }
        //check left
        if (col > 0 && grid[row, col - 1].isVisited)
        {
            return true;
        }
        //check right
        if (col < Coloumns - 1 && grid[row, col + 1].isVisited)
        {
            return true;
        }
        return false;
    }
}