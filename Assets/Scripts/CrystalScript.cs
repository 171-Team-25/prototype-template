using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CrystalScript : Damageable
{
    [SerializeField] teamName team = teamName.red;

    private void Start()
    {
        GameManager.Instance.AddCrystal(gameObject);
        if (team == teamName.red)
        {
            this.GetComponent<Renderer>().material.color = Color.red;
        }
        if (team == teamName.blue)
        {
            this.GetComponent<Renderer>().material.color = Color.blue;
        }
        health = maxHealth;
    }
    public override void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            //PLAY DEATH ANIMATION
            GameManager.Instance.DestroyCrystal(gameObject);
            Debug.Log(this.name.ToString() + " DIED");
        }
    }

    public teamName GetTeam()
    {
        return team;
    }

    public void Spawn()
    {
        health = maxHealth;
        gameObject.SetActive(true);
    }
}