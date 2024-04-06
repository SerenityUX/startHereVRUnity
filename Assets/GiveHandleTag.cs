using UnityEngine;

public class GiveHandleTag : MonoBehaviour
{
    private Vector3 originalLocalPosition; // To keep track of the original position relative to the parent
    private bool isReturningToOriginalPosition = false; // Flag to indicate the object is returning to its original position

    public float returnSpeed = 1.0f; // Speed at which the object returns to its original position

    void Start()
    {
        // Initialize originalLocalPosition with the current local position at start
        originalLocalPosition = transform.localPosition;
    }

    void Update()
    {
        // Check if the position has changed significantly (using localPosition for relative movement)
        if (transform.localPosition != originalLocalPosition && !isReturningToOriginalPosition)
        {
            UpdateTagIfNeeded();
            isReturningToOriginalPosition = true; // Start returning to the original position
        }

        if (isReturningToOriginalPosition)
        {
            // Move back to the original position smoothly
            transform.localPosition = Vector3.Lerp(transform.localPosition, originalLocalPosition, Time.deltaTime * returnSpeed);

            // Check if the object has nearly reached its original position
            if (Vector3.Distance(transform.localPosition, originalLocalPosition) < 0.001f)
            {
                transform.localPosition = originalLocalPosition; // Snap to the exact original position
                isReturningToOriginalPosition = false; // Stop returning to the original position
            }
        }
    }

    void UpdateTagIfNeeded()
    {
        // Check if the current tag is not "Handle", then update it
        if (!gameObject.CompareTag("Handle"))
        {
            gameObject.tag = "Handle";
        }
    }
}
