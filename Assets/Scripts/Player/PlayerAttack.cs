using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    public GameObject projectilePrefab;   // The projectile (ball) prefab to shoot
    public float attackForce = 25f;       // The force with which the projectile is shot
    public float spawnOffset = 1f;        // Offset distance to spawn the projectile outside the character
    public float rotationSpeed = 10f;     // The speed at which the player rotates toward the shooting direction

    private Camera playerCam;
    private bool canShoot = true;         // Variable to prevent multiple shots per click
    private Vector3 ControllerDirection;

    private void Start()
    {
        // Get the main camera reference
        playerCam = GetComponentInChildren<Camera>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        ControllerDirection = context.ReadValue<Vector2>();
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.started && canShoot)
        {
            if(context.control.device is Mouse)
            {
                Vector3 mouseScreenPos = Mouse.current.position.ReadValue();
                Ray ray = playerCam.ScreenPointToRay(mouseScreenPos);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    Vector3 targetPosition = hit.point;
                    Vector3 direction = (targetPosition - transform.position).normalized;
                    direction.y = 0.0f;  // Ensure the player only rotates on the y-axis
                    Vector3 spawnPosition = transform.position + direction * spawnOffset;
                    GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
                    projectile.GetComponent<ProjectileScript>().SetShooter(gameObject);
                    Rigidbody rb = projectile.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.AddForce(direction * attackForce, ForceMode.Impulse);
                    }
                    canShoot = false;
                }
            }
            else
            {
                Vector3 direction = ControllerDirection.normalized;
                direction.y = 0.0f;  // Ensure the player only rotates on the y-axis
                Vector3 spawnPosition = transform.position + direction * spawnOffset;
                GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
                projectile.GetComponent<ProjectileScript>().SetShooter(gameObject);
                Rigidbody rb = projectile.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddForce(direction * attackForce, ForceMode.Impulse);
                }
                canShoot = false;
            }
                
        }
        else if (context.canceled)
        {
            canShoot = true;
        }
    }
}
