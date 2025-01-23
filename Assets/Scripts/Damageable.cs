using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] protected float maxHealth = 100f;
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        //PLAY DEATH ANIMATION
        Destroy(gameObject);
        Debug.Log(this.name.ToString() + " DIED");
    }
}
