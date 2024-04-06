using UnityEngine;

public class DragonController : MonoBehaviour
{
    public GameObject handle1;
    public GameObject handle2;
    public float speed = 1f; // Speed at which the dragon moves
    public float rotationSpeed = 1f; // Speed at which the dragon rotates towards the target direction

    void Update()
    {
        if (handle1 != null && handle2 != null && handle1.CompareTag("Handle") && handle2.CompareTag("Handle"))
        {
            // Calculate the direction from handle1 to handle2 in world space
            Vector3 targetDirection = handle2.transform.position - handle1.transform.position;

            // Create a target rotation based on the direction vector
            Quaternion initialTargetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);

            // Add a 90-degree offset in the Y-axis to the target rotation
            Quaternion targetRotationWithOffset = Quaternion.Euler(initialTargetRotation.eulerAngles.x, initialTargetRotation.eulerAngles.y - 90, initialTargetRotation.eulerAngles.z);

            // Smoothly interpolate the dragon's rotation towards the target rotation with the 90-degree offset
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotationWithOffset, rotationSpeed * Time.deltaTime);

            // Move the dragon forward relative to its current rotation
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
        }
    }
}
