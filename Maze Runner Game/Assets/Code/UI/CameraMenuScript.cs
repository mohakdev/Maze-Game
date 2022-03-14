using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMenuScript : MonoBehaviour
{
    public float Speed;
    private void Update()
    {
        if (transform.position.z <= -4)
        {
            transform.position += new Vector3(0, 0, 0.3f) * Time.deltaTime * Speed;
        }
        else
        {
            transform.position = new Vector3(-127, 4, -44);
        }
    }
}
