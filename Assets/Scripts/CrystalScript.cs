using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CrystalScript : Damageable
{
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

    public override void Die()
    {
        Debug.Log(this.name.ToString() + " DIED");
        GameManager.Instance.DestroyCrystal(gameObject);
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