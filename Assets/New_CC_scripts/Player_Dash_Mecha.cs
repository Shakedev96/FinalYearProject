using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Dash_Mecha : MonoBehaviour
{
    public float dashSpeed = 10f; // Dash speed
    public float dashDuration = 0.2f; // Duration of the dash
    public float dashCooldown = 1f; // Cooldown before the player can dash again

    private bool isDashing = false; // Whether the player is dashing
    private float dashTime = 0f; // Time spent dashing
    private float lastDashTime = 0f; // Time of the last dash

    private CharacterController controller; // CharacterController component
    private Vector3 dashDirection; // Direction of the dash

    void Start()
    {
        controller = GetComponent<CharacterController>(); // Get the CharacterController
    }

    void Update()
    {
        // Check for Dash input (Shift key) and ensure cooldown is respected
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing && Time.time >= lastDashTime + dashCooldown)
        {
            StartDash(); // Start the dash if conditions are met
        }

        // Handle the dash movement if the player is dashing
        if (isDashing)
        {
            HandleDash();
        }
    }

    // Start the dash, set direction and time
    void StartDash()
    {
        isDashing = true;
        dashTime = 0f; // Reset dash time
        lastDashTime = Time.time; // Set the last dash time

        // Get the player's movement direction from input
        float moveX = Input.GetAxisRaw("Horizontal"); // Get horizontal input (A/D or Left/Right Arrow)
        float moveZ = Input.GetAxisRaw("Vertical");   // Get vertical input (W/S or Up/Down Arrow)

        // Normalize the direction to prevent diagonal speed increase
        dashDirection = new Vector3(moveX, 0f, moveZ).normalized;
    }

    // Handle the dash movement during the dash phase
    void HandleDash()
    {
        dashTime += Time.deltaTime; // Increment dash time

        if (dashTime < dashDuration)
        {
            // Move the player in the dash direction
            controller.Move(dashDirection * dashSpeed * Time.deltaTime);
        }
        else
        {
            // Stop dashing after the duration ends
            isDashing = false;
        }
    }
}
