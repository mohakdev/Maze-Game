using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Variables

    //Other Methods
    public void QuitGame()
    {
        Application.Quit();
    }
    public void OnHoverEnter(Text Label)
    {
        Label.fontSize = 130;
    }
    public void OnHoverExit(Text Label)
    {
        Label.fontSize = 120;
    }
}
