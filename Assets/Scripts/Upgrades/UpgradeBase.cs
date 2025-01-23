using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradeType
{
    damage,
    heal,
    defensive,
    buff,
    other
}

public class UpgradeBase : MonoBehaviour
{
    public float effectValue = 1f; //Damage number, healing number, shield number, etc.
    public UpgradeType upgradeType;
}
