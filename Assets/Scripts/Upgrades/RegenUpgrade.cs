using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenUpgrade : UpgradeBase
{
    public float healInterval = 5f;
    void Start()
    {
        effectValue = 10f;
        InvokeRepeating("healPlayer", healInterval, healInterval);
    }

    private void healPlayer()
    {
        GetComponent<PlayerClass>().health += effectValue;
        if (GetComponent<PlayerClass>().health >= GetComponent<PlayerClass>().maxHealth)
        {
            GetComponent<PlayerClass>().health = GetComponent<PlayerClass>().maxHealth;
        }
    }
}
