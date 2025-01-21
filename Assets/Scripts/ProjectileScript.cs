using System.Collections;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [Header("Projectile Settings")]
    public float lifetime = 5f;  // Time after which the projectile is destroyed if no collision happens
    public float damage = 25f;   // Damage dealt by the projectile

    private GameObject shooter;  // Reference to the player (shooter) who fired the projectile

    private void Start()
    {
        // Store the shooter (player) who fired the projectile
        shooter = transform.root.gameObject;

        // Destroy the projectile after a set lifetime if it doesn't collide with anything
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Ignore collision with the shooter (player)
        if (other.gameObject == shooter)
        {
            return;  // Skip collision handling if it’s the shooter
        }

        // Check if the object hit is Damageable
        Damageable damageable = other.GetComponent<Damageable>();
        if (damageable != null)
        {
            // Apply damage to the Damageable object
            damageable.TakeDamage(damage);
        }

        // Destroy the projectile upon collision
        Destroy(gameObject);
    }
}
