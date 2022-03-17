using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    // Variables
    CharacterController cc;
    AudioSource audioPlayer;
    private void Awake()
    {
        cc = GetComponent<CharacterController>();
        audioPlayer = GetComponent<AudioSource>();
        audioPlayer.volume = PlayerPrefs.GetFloat("Volume", 1);
    }
    //Update Method
    void Update()
    {
        if (cc.isGrounded && cc.velocity.magnitude > 0 && !audioPlayer.isPlaying)
        {
            //audioPlayer.volume = Random.Range(0.8f, 1);
            audioPlayer.pitch = Random.Range(0.7f, 1.2f);
            audioPlayer.Play();
        }
    }
}
