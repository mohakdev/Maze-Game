using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject PauseScreen;
    public GameObject Settings;
    public GameObject FinshedScreen;
    bool isActive = false;
    //Update Method
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !Settings.activeSelf && !FinshedScreen.activeSelf)
        {
            if (!isActive)
            {
                PauseScreen.SetActive(true);
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                isActive = true;
            }
            else
            {
                PauseScreen.SetActive(false);
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                isActive = false;
            }
        }
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
    public void LoadMenu()
    {
        Time.timeScale = 1;
        LevelLoader.LoadNewLevel(LevelLoader.AllScenes.MainMenu);
    }
    public void Resume()
    {
        PauseScreen.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        isActive = false;
    }
}
