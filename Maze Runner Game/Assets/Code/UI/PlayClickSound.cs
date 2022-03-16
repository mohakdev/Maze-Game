using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class PlayClickSound : MonoBehaviour
{
    // Variables
    AudioSource AudioPlayer;
    //Other Methods
    private void Awake()
    {
        AudioPlayer = GetComponent<AudioSource>();
    }
    public void ClickingSound()
    {
        AudioPlayer.Play();
    }
}
