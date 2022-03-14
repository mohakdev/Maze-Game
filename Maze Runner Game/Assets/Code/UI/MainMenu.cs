using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Variables
    public AudioClip HoverSound;
    public static string DifficultyMode = "easy";
    //Other Methods
    public void LoadGame(string Mode)
    {
        DifficultyMode = Mode;
        LevelLoader.LoadNewLevel(LevelLoader.AllScenes.Gameplay);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void OnHoverEnter(Text Label)
    {
        Label.fontSize = 130;
        //MenuSounds.Instance.PlaySound(HoverSound);
    }
    public void OnHoverExit(Text Label)
    {
        Label.fontSize = 120;
    }
}
