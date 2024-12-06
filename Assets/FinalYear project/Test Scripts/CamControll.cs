using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControll : MonoBehaviour
{
   [Header("Target Settings")]
    [SerializeField] private Transform playerTransform;  
    [SerializeField] private Vector3 offset = new Vector3(0, 5, -10);  
    [Header("Follow Smoothness")]
    [SerializeField, Range(0f, 1f)] private float smoothSpeed = 0.125f;  

    [Header("Boundary Settings")]
    [SerializeField] private bool useBoundaries = false;  
    [SerializeField] private Vector3 minBoundary;  
    [SerializeField] private Vector3 maxBoundary;  

    private void LateUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        
        Vector3 desiredPosition = playerTransform.position + offset;

       
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        
        if (useBoundaries)
        {
            smoothedPosition.x = Mathf.Clamp(smoothedPosition.x, minBoundary.x, maxBoundary.x);
            smoothedPosition.y = Mathf.Clamp(smoothedPosition.y, minBoundary.y, maxBoundary.y);
            smoothedPosition.z = Mathf.Clamp(smoothedPosition.z, minBoundary.z, maxBoundary.z);
        }

       
        transform.position = smoothedPosition;

        

        transform.LookAt(playerTransform);
    }

}
