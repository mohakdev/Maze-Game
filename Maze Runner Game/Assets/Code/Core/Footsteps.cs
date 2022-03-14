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

        Printer.OnlyPrintMsg("Magnitude:" + cc.velocity.magnitude.ToString());
        if (cc.isGrounded && cc.velocity.magnitude > 2f && !audioPlayer.isPlaying)
        {
            audioPlayer.Play();
        }
    }
}
