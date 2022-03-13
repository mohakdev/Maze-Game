using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject PauseScreen;
    bool isActive = false;
    //Update Method
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print(isActive);
            if (!isActive)
            {
                PauseScreen.SetActive(true);
                Time.timeScale = 0;
                isActive = true;
            }
            else
            {
                PauseScreen.SetActive(false);
                Time.timeScale = 1;
                isActive = false;
            }
        }
    }
}
