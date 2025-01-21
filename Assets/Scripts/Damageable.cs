using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] float maxHealth = 100f;
    private float health;
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
            //PLAY DEATH ANIMATION
            Destroy(gameObject);
            Debug.Log(this.name.ToString() + " DIED");
        }
    }
}
