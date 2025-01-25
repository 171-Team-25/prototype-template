using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum AbilityType
{
    Fireball,
    Heal,
    Temp
}
public enum AbilityTargetingType
{
    CursorTargeted,  // shooting
    SelfTargeted     // buffs (heals, etc)
}
[CreateAssetMenu(fileName = "New Ability", menuName = "Ability/AbilitySO")]
public class AbilitySO : ScriptableObject
{
    [Header("Ability Settings")]
    public GameObject abilityPrefab;   // The ability prefab (e.g., Fireball)
    public KeyCode keybind;           // Keybind for the ability (1, 2, 3, etc.)
    public AbilityType abilityType;
    public AbilityTargetingType targetingType;  // Determines how the ability is aimed
    public float cooldownDuration;    // Cooldown duration in seconds

}
