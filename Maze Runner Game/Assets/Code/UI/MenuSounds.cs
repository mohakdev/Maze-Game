using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class MenuSounds : MonoBehaviour
{
    // Variables
    public static MenuSounds Instance;
    AudioSource AudioPlayer;
    //Other Methods
    private void Awake()
    {
        Instance = this;
        AudioPlayer = GetComponent<AudioSource>();
    }
    public void PlaySound(AudioClip music)
    {
        AudioPlayer.clip = music;
        AudioPlayer.Play();
    }
}
