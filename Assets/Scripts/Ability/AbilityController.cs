using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class AbilityController : MonoBehaviour
{
    [System.Serializable]
    public class AbilityData
    {
        public AbilitySO abilitySO;       
        public Image abilityIconUI;        
        public TMP_Text cooldownTextUI;    

        public float cooldownTimer;        
        public bool isOnCooldown;         
    }

    public List<AbilityData> abilities = new List<AbilityData>(); // List of abilities
    //private bool canUseAbility = true;   // Flag to allow ability usage
    public Camera playerCamera;


    void Update()
    {
        HandleAbilityInput();  
  
    }

    // Handle the key input for abilities
    void HandleAbilityInput()
    {
        foreach (var ability in abilities)
        {
            if (Input.GetKeyDown(ability.abilitySO.keybind) && !ability.isOnCooldown)
            {
                ActivateAbility(ability);
            }
        }
    }
    void ActivateAbility(AbilityData ability)
    {
        // mouse position on player_camera
        Vector3 mouseScreenPos = Input.mousePosition;

        // Convert screen position to a world position using player's unique camera
        Ray ray = playerCamera.ScreenPointToRay(mouseScreenPos);
        RaycastHit hit;

        Vector3 targetDirection;
        if (Physics.Raycast(ray, out hit))
        {
            // if exists, calcuate location 
            targetDirection = (hit.point - transform.position).normalized;
        }
        else
        {
            // Default forward direction if no hit occurs
            targetDirection = transform.forward;
        }

        // spawn ability abit off player position 
        Vector3 spawnPosition = transform.position + targetDirection * 2f;
        GameObject abilityObject = Instantiate(ability.abilitySO.abilityPrefab, spawnPosition, Quaternion.LookRotation(targetDirection));

        // move projectile to move in the targetl location
        AbilityProjectile projectile = abilityObject.GetComponent<AbilityProjectile>();
        if (projectile != null)
        {
            projectile.SetDirection(targetDirection);
        }

        StartCoroutine(AbilityCooldownRoutine(ability));
    }

    // Handle the ability's cooldown timer
    IEnumerator AbilityCooldownRoutine(AbilityData ability)
    {
        ability.isOnCooldown = true;
        ability.cooldownTimer = ability.abilitySO.cooldownDuration;

        // while cd -> update timer and dim -- DIM ISN"T WORKING
        while (ability.cooldownTimer > 0)
        {
            ability.cooldownTimer -= Time.deltaTime;
            ability.abilityIconUI.fillAmount = .1f; // dim
            ability.cooldownTextUI.text = Mathf.Ceil(ability.cooldownTimer).ToString(); // update ui with timer

            yield return null;
        }

        // reset when no cooldown
        ability.abilityIconUI.fillAmount = 1;
        ability.cooldownTextUI.text = ""; 
        ability.isOnCooldown = false;
    }
}

