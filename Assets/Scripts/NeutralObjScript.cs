using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralObjScript : Damageable
{
    public override bool TakeDamage(float damage, teamName team)
    {
        if (team != this.team)
        {
            health -= damage;
            if (health <= 0)
            {
                Die();
                GameManager.Instance.BuffTeam(team);
            }
            return true;
        }
        else
        {
            return false;
        }
    }
}
