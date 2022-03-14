using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public MazeGenerator maze;
    //Start Method
    void Start()
    {
        string Mode = MainMenu.DifficultyMode;
        if (Mode.Equals("easy"))
        {
            maze.SetSize(10); //We will generate 10 rows and coloumns
            maze.GenerateMaze();
        }
        else if (Mode.Equals("medium"))
        {
            maze.SetSize(20); //We will generate 20 rows and coloumns
            maze.GenerateMaze();
        }
        else if (Mode.Equals("hard"))
        {
            maze.SetSize(30); //We will generate 30 rows and coloumns
            maze.GenerateMaze();
        }
    }
}
