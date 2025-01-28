using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpeedBoostActiveUpgrade : ActiveAbility
{
    private float speedBoostMultiplier = 2.0f;
    private void Start()
    {
        cooldownTime = 8.0f;
        onCooldown = false;
        gameObject.GetComponent<PlayerClass>().AddActiveAvility(this);
    }
    public override void Cast()
    {
        Debug.Log(onCooldown);
        if (!onCooldown)
        {
            gameObject.GetComponent<PlayerMovement>().moveSpeed *= speedBoostMultiplier;
            StartCoroutine(revert());
            base.Cast();
        }
    }

    private IEnumerator revert()
    {
        yield return new WaitForSeconds(3);
        gameObject.GetComponent<PlayerMovement>().moveSpeed /= speedBoostMultiplier;
    }
}
