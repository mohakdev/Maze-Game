using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishedGameScript : MonoBehaviour
{
    // Variables
    public Text Timer;
    public Text TimeLabel;
    private void OnEnable()
    {
        TimeLabel.text = Timer.text;
        Timer.gameObject.SetActive(false);
    }

    public void OnHoverEnter(Text Label)
    {
        Label.fontSize = 130;
    }
    public void OnHoverExit(Text Label)
    {
        Label.fontSize = 120;
    }
    public void LoadMenu()
    {
        LevelLoader.LoadNewLevel(LevelLoader.AllScenes.MainMenu);
    }
}
