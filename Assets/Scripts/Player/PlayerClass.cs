using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum teamName{
    red,
    blue
}

public class PlayerClass : Damageable
{
    private teamName team;

    void Start()
    {
        health = maxHealth;
        GameManager.Instance.AddPlayer(gameObject);
        team = GameManager.Instance.AssignTeam(gameObject);
        if(team == teamName.red)
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
        
    }

    public override void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            //PLAY DEATH ANIMATION
            GameManager.Instance.PlayerDie(gameObject);
            Debug.Log(this.name.ToString() + " DIED");
        }
    }

    public teamName GetTeam()
    {
        return team;
    }

    public void Respawn(Transform spawnPoint, float time)
    {
        StartCoroutine(RespawnCoroutine(spawnPoint, time));
    }

    private IEnumerator RespawnCoroutine(Transform spawnPoint, float time)
    {
        yield return new WaitForSeconds(time);
        transform.position = spawnPoint.position;
        transform.rotation = spawnPoint.rotation;
        gameObject.SetActive(true);
    }

}
