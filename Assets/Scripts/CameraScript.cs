using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform player; // The player to follow

    [Header("Camera Settings")]
    public Vector3 offset = new Vector3(0, 10, -12); // Offset position relative to the player
    public float xRotation = 45f; // Fixed x-rotation of the camera

    [Header("Follow Settings")]
    public float followSpeed = 5f; // Speed at which the camera follows the player

    private void Start()
    {
        player = transform.parent;
    }

    private void LateUpdate()
    {
        if (player == null)
        {
            Debug.LogWarning("Player reference is missing!");
            return;
        }

        // Calculate the desired position
        Vector3 desiredPosition = player.position + player.TransformDirection(offset);

        desiredPosition.y += 5;
        desiredPosition.z -= 13;

        // Smoothly move the camera to the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // Set the camera's rotation
        transform.rotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
