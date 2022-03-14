using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelLoader
{
    public enum AllScenes
    {
        MainMenu,
        Gameplay
    }
    public static void LoadNewLevel(AllScenes scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
