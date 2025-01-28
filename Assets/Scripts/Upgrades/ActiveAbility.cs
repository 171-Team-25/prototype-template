using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAbility : UpgradeBase
{
    public float cooldownTime = 5f;
    public bool onCooldown = false;
    public virtual void Cast()
    {
        StartCoroutine(CD());
    }
    private IEnumerator CD()
    {
        if (!onCooldown)
        {
            onCooldown = true;
            yield return new WaitForSeconds(cooldownTime);
            onCooldown = false;
        }
        
    }
}
