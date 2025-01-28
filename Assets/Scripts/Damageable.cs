using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health;
    public teamName team;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public virtual bool TakeDamage(float damage, teamName team)
    {
        if (team != this.team)
        {
            health -= damage;
            if (health <= 0)
            {
                Die();
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    public virtual void Die()
    {
        //PLAY DEATH ANIMATION
        Destroy(gameObject);
        Debug.Log(this.name.ToString() + " DIED");
    }
}
