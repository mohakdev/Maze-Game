using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    // Variables
    public static SoundPlayer Instance;
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
