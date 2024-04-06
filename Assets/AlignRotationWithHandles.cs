using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignRotationWithHandles : MonoBehaviour
{
    private Vector3 previousPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize previousPosition with the current position at the start
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the direction of movement by subtracting the previous position from the current position
        Vector3 directionOfMovement = transform.position - previousPosition;

        // Check if there is significant movement
        if (directionOfMovement.magnitude > 0.01f)
        {
            // Normalize the direction of movement since we're only interested in the direction
            directionOfMovement.Normalize();

            // Create a new rotation that looks in the direction of movement with the up vector as the world y-axis
            // Assuming you want to align on the Y axis, we'll project the direction on the XZ plane
            Vector3 directionOnXZPlane = new Vector3(directionOfMovement.x, 0, directionOfMovement.z);
            if (directionOnXZPlane != Vector3.zero) // Avoid setting a look rotation with a zero vector
            {
                Quaternion newRotation = Quaternion.LookRotation(directionOnXZPlane, Vector3.up);

                // Set the rotation of this GameObject to the new rotation
                transform.rotation = newRotation;
            }
        }

        // Update previousPosition with the current position at the end of the frame
        previousPosition = transform.position;
    }
}
