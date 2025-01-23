using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUpgrade : UpgradeBase
{
    private GameObject prefab, shield;

    void Start()
    {
        prefab = Resources.Load<GameObject>("Prefabs/PlayerForcefield");
        upgradeType = UpgradeType.defensive;
        effectValue = 100f;
        shield = Instantiate(prefab, transform.position, Quaternion.Euler(-90, 0, 0), transform);
        shield.AddComponent<Damageable>().maxHealth = 100f;
        shield.GetComponent<Damageable>().team = GetComponent<PlayerClass>().team;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
