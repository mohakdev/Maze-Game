using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    // Variables
    public GameObject ExitGate;
    public GameObject EndScreen;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.Equals(ExitGate))
        {
            Cursor.lockState = CursorLockMode.None;
            TimerScript.instance.EndTimer();
            EndScreen.SetActive(true);
        }
    }
}
