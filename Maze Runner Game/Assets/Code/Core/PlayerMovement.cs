using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    public float speed = 12f;

    public float jumpHeight = 3f;
    public float gravity = -9.81f;
    Vector3 Velocity;
    void Update()
    {
        controller = GetComponent<CharacterController>();

        if (controller.isGrounded && Velocity.y < 0)
        {
            Velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        Velocity.y += gravity * Time.deltaTime;
        move = move * speed * Time.deltaTime;
        move.y = Velocity.y * Time.deltaTime;
        controller.Move(move);

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            Velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}
