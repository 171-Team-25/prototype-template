using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The player that the camera will follow
    public float followHeight = 20f; // Height of the camera above the player
    public float smoothSpeed = 0.125f; // How smoothly the camera follows the player
    public Vector3 offset; // Offset from the target

    private void LateUpdate()
    {
        // Set the camera position to follow the target player but keep the fixed height
        Vector3 desiredPosition = target.position + offset;
        desiredPosition.y = followHeight;  // Keep height fixed for top-down view
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Keep the camera looking straight down
        transform.LookAt(target.position + Vector3.up * 5f);  // Adjust Vector3.up as needed
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        offset = new Vector3(0, 0, 0); // Adjust if you want an offset in camera position
    }
}

