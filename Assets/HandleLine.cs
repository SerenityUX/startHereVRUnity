using UnityEngine;

public class HandleLineRenderer : MonoBehaviour
{
    // Tag to identify objects to connect
    public string handleTag = "Handle";

    // Reference to LineRenderer component
    private LineRenderer lineRenderer;

    void Start()
    {
        // Check if LineRenderer component is already attached
        lineRenderer = GetComponent<LineRenderer>();

        // If LineRenderer component doesn't exist, create one
        if (lineRenderer == null)
        {
            // Create a new GameObject with LineRenderer component
            GameObject lineObject = new GameObject("LineRenderer");
            lineRenderer = lineObject.AddComponent<LineRenderer>();
        }

        // Set the width of the line
        lineRenderer.startWidth = 0.04f;
        lineRenderer.endWidth = 0.04f;

        UpdateLineRenderer();
    }

    void Update()
    {
        // Update the line renderer continuously
        UpdateLineRenderer();
    }

    void UpdateLineRenderer()
    {
        // Find all objects with the specified tag
        GameObject[] handles = GameObject.FindGameObjectsWithTag(handleTag);

        // Check if there are enough handles to draw a line
        if (handles.Length < 2)
        {
            Debug.LogWarning("Not enough objects with tag 'Handle' to draw a line.");
            return;
        }

        // Set the number of points in the line renderer to match the number of handles
        lineRenderer.positionCount = handles.Length;

        // Set the positions of the line renderer to match the positions of the handles
        for (int i = 0; i < handles.Length; i++)
        {
            lineRenderer.SetPosition(i, handles[i].transform.position);
        }
    }
}
