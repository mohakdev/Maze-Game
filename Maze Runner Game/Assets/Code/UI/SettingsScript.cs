using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    // Variables
    float Sensitivity;
    float Volume;
    public Slider SensSlider;
    public Slider VolSlider;

    private void Start()
    {
        Sensitivity = PlayerPrefs.GetFloat("Senstivity", 100);
        Volume = PlayerPrefs.GetFloat("Volume", 1);

        SensSlider.value = Sensitivity;
        VolSlider.value = Volume;
    }
    //This runs when player changes the default value of Senstivity slider
    public void SensSliderChanged(float sens)
    {
        PlayerPrefs.SetFloat("Senstivity", sens);
        PlayerCamera.NewSenstivity();
    }
    //This runs when player changes the default value of Volume slider
    public void VolumeSliderChanged(float vol)
    {
        PlayerPrefs.SetFloat("Volume", vol);
        PlayerCamera.NewSenstivity();
    }

    public void OnHoverEnter(Text Label)
    {
        Label.fontSize = 110;
        //MenuSounds.Instance.PlaySound(HoverSound);
    }
    public void OnHoverExit(Text Label)
    {
        Label.fontSize = 100;
    }
}
