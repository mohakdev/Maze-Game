using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    /*This class sets the Timer to ON
     Set The Maze Generation Size and 
    Sets Player Position*/
    public MazeGenerator maze;
    Vector3 PlayerEasyPos = new Vector3(90, 5, -80);
    Vector3 PlayerMedPos = new Vector3(190, 5, -170);
    Vector3 PlayerHardPos = new Vector3(290, 5, -280);
    void Awake()
    {
        string Mode = MainMenu.DifficultyMode;
        if (Mode.Equals("easy"))
        {
            maze.SetSize(10); //We will generate 10 rows and coloumns
            maze.GenerateMaze();
            transform.position = PlayerEasyPos;
        }
        else if (Mode.Equals("medium"))
        {
            maze.SetSize(20); //We will generate 20 rows and coloumns
            maze.GenerateMaze();
            transform.position = PlayerMedPos;
        }
        else if (Mode.Equals("hard"))
        {
            maze.SetSize(30); //We will generate 30 rows and coloumns
            maze.GenerateMaze();
            transform.position = PlayerHardPos;
        }
    }
}
