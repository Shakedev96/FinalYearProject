using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Light_Stamina : MonoBehaviour
{
    public CharacterController controller; // Reference to the CharacterController
    public Light pointLight;              // Reference to the Point Light
    public float maxIntensity = 5f;       // Maximum light intensity
    public float minIntensity = 0f;       // Minimum light intensity
    public float drainRate = 1f;          // How fast the intensity drains
    public float refillRate = 2f;         // How fast the intensity refills

    private bool isMoving;

    void Update()
    {
        // Check if the player is moving
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        isMoving = moveX != 0 || moveZ != 0;

        if (isMoving)
        {
            // Refill the light intensity when moving
            pointLight.intensity = Mathf.Min(maxIntensity, pointLight.intensity + refillRate * Time.deltaTime);
        }
        else
        {
            // Reduce the light intensity when idle
            pointLight.intensity = Mathf.Max(minIntensity, pointLight.intensity - drainRate * Time.deltaTime);
        }
    }
}
