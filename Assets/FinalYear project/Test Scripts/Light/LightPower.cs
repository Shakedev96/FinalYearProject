using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightPower : MonoBehaviour
{
    public float minIntensity = 50f, maxIntensity = 1200f, currentIntensity, intensityIncreaseRate, intensityDecreaseRate;

    [SerializeField] private KeyCode lightUpKey, lightDownKey;
    private Light playerLight;
    // Start is called before the first frame update
    void Start()
    {
        playerLight = GetComponentInChildren<Light>();

        currentIntensity = playerLight.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        ControlLight();
    }

    void ControlLight()
    {
        if (Input.GetKey(lightUpKey))
        {
            Debug.Log("LightKey pressed" + " current intensity is " + playerLight.intensity);
            currentIntensity += intensityIncreaseRate * Time.deltaTime;
            currentIntensity = Mathf.Clamp(currentIntensity, minIntensity, maxIntensity);
            playerLight.intensity = currentIntensity;
        }
        else if (Input.GetKeyDown(lightDownKey))
        {
            currentIntensity -= intensityDecreaseRate * Time.deltaTime;
            currentIntensity = Mathf.Clamp(currentIntensity, minIntensity, maxIntensity);
            playerLight.intensity = currentIntensity;
            Debug.Log("Light key released.");
        }
        
    }
}
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPower : MonoBehaviour
{
    public float minIntensity = 50f, maxIntensity = 1200f; // Range for light intensity
    public float intensityIncreaseRate = 50f; // How quickly the intensity increases
    private float currentIntensity;

    [SerializeField] private KeyCode lightKey; // Key to control the light
    private Light playerLight;

    void Start()
    {
        playerLight = GetComponentInChildren<Light>();
        currentIntensity = playerLight.intensity; // Initialize current intensity
    }

    void Update()
    {
        ControlLight();
    }

    void ControlLight()
    {
        // Check if the light key is held down
        if (Input.GetKey(lightKey))
        {
            // Increase light intensity while the key is pressed
            currentIntensity += intensityIncreaseRate * Time.deltaTime;
            currentIntensity = Mathf.Clamp(currentIntensity, minIntensity, maxIntensity); // Clamp to max
            playerLight.intensity = currentIntensity;
        }
        else if (Input.GetKeyUp(lightKey))
        {
            // Optional: Stop increasing intensity when the key is released
            Debug.Log("Light key released.");
        }
    }
}

*/
