using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    // Variables
    public GameObject Player;

    //Methods
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.Equals(Player))
        {
            print("Game Ended");
        }
    }
}
