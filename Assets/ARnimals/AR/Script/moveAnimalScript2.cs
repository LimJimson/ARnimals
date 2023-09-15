using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAnimalScript2 : MonoBehaviour
{
    public float floatSpeedX = 0.5f;
    public float floatAmplitudeX = -0.4f;  // Change the sign to move in the opposite direction along the x-axis
    public float floatSpeedZ = 0.5f;
    public float floatAmplitudeZ = -0.3f;  // Change the sign to move in the opposite direction along the z-axis
    public float rotationSpeed = 3.0f;

    private Vector3 startPosition;
    private float floatPhaseX = 0.0f;
    private float floatPhaseZ = 0.0f;

    private void Awake()
    {
        
    }
    private void Start()
    {
        startPosition = transform.position;

    }

    private void Update()
    {
        // Calculate the float motion along the x-axis.
        floatPhaseX += floatSpeedX * Time.deltaTime;
        float xOffset = Mathf.Sin(floatPhaseX) * floatAmplitudeX;

        // Calculate the float motion along the z-axis.
        floatPhaseZ += floatSpeedZ * Time.deltaTime;
        float zOffset = Mathf.Sin(floatPhaseZ) * floatAmplitudeZ;

        Vector3 floatPosition = startPosition + new Vector3(xOffset, 0.0f, zOffset);

        // Calculate the movement direction.
        Vector3 moveDirection = (floatPosition - transform.position).normalized;

        // Move to the float position.
        transform.position = floatPosition;

        // Rotate to face the movement direction.
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
