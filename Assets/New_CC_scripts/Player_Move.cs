using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public CharacterController controller;

    public float moveSpeed = 5f;    // Speed of movement
    public float jumpHeight = 2f;  // Jump height
    public float gravity = -9.81f; // Gravity force

    private Vector3 velocity;      // Tracks vertical velocity
    private bool isGrounded;       // Checks if player is grounded

    void Update()
    {
        // Check if the player is grounded
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Reset vertical velocity to keep player grounded
        }

        // Horizontal and depth movement (X and Z axis)
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow
        float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down Arrow
        Vector3 move = new Vector3(moveX, 0, moveZ); // Move on X and Z axes
        controller.Move(move * moveSpeed * Time.deltaTime);

        // Jump logic
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // Calculate jump velocity
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        // Apply vertical movement (gravity and jump combined)
        controller.Move(velocity * Time.deltaTime);
    }
}
