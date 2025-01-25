using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public enum teamName
{
    red,
    blue, 
    neutral,
}

public class PlayerClass : Damageable
{
    void Start()
    {
        health = maxHealth;
        GameManager.Instance.AddPlayer(gameObject);
        team = GameManager.Instance.AssignTeam(gameObject);
        if (team == teamName.red)
        {
            this.GetComponent<Renderer>().material.color = Color.red;
        }
        if (team == teamName.blue)
        {
            this.GetComponent<Renderer>().material.color = Color.blue;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //gameObject.AddComponent<AsolUpgrade>();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gameObject.AddComponent<AsolUpgrade>();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            gameObject.AddComponent<ShieldUpgrade>();
        }
    }

    public override void Die()
    {
        GameManager.Instance.PlayerDie(gameObject);
        Debug.Log(this.name.ToString() + " DIED");
    }

    public teamName GetTeam()
    {
        return team;
    }

    public void Respawn(Vector3 spawnPoint, float time)
    {
        StartCoroutine(RespawnCoroutine(spawnPoint, time));
    }

    private IEnumerator RespawnCoroutine(Vector3 spawnPoint, float time)
    {
        yield return new WaitForSeconds(time);
        transform.position = spawnPoint;
        gameObject.SetActive(true);
    }

}