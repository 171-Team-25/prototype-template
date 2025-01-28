using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class OneShotActiveUpgrade : ActiveAbility
{
    Camera playerCam;
    float spawnOffset = 1.0f;
    void Start()
    {
        playerCam = GetComponentInChildren<Camera>();
        cooldownTime = 5.0f;
        onCooldown = false;
        gameObject.GetComponent<PlayerClass>().AddActiveAvility(this);
    }

    public override void Cast()
    {
        if (!onCooldown)
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
                GameObject deathSphere = Resources.Load<GameObject>("Prefabs/Sphere");
                GameObject projectile = Instantiate(deathSphere, spawnPosition, Quaternion.identity);
                projectile.GetComponent<Renderer>().material.color = Color.black;
                projectile.GetComponent<ProjectileScript>().SetShooter(gameObject);
                projectile.GetComponent<ProjectileScript>().damage = 100.0f;
                Rigidbody rb = projectile.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddForce(direction * 15.0f, ForceMode.Impulse);
                }
            }
            base.Cast();
        }
    }
        
}
