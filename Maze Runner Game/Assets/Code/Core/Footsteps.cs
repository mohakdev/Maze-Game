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
    }
    //Update Method
    void Update()
    {
        if (cc.isGrounded && cc.velocity.magnitude > 0 && !audioPlayer.isPlaying)
        {
            audioPlayer.Play();
        }
    }
}
