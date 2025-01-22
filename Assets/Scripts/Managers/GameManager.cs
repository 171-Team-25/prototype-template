using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;

public enum GamePhase
{
    Upgrade,
    Combat
}
public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;  // Your player prefab
    public Camera player1Camera;  // Camera for Player 1
    public Camera player2Camera;  // Camera for Player 2
    public GamePhase CurrentPhase { get; private set; } = GamePhase.Upgrade;

    public static GameManager Instance { get; private set; }

    private List<GameObject> playerList = new List<GameObject>();
    private List<GameObject> redTeam = new List<GameObject>();
    private List<GameObject> blueTeam = new List<GameObject>();
    private bool redCanSpawn = true, blueCanSpawn = true;

    private List<GameObject> crystalList = new List<GameObject>();
    private List<GameObject> redCrystals = new List<GameObject>();
    private List<GameObject> blueCrystals = new List<GameObject>();

    public Transform redSpawnPoint;
    public Transform blueSpawnPoint;

    private int redScore = 0, blueScore = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        TransitionToNextPhase();
        redSpawnPoint = GameObject.Find("RedSpawn").transform;
        blueSpawnPoint = GameObject.Find("BlueSpawn").transform;
    }

    public void StartUpgradePhase()
    {
        CurrentPhase = GamePhase.Upgrade;
        Debug.Log("Upgrade phase started.");

        // Add logic specific to the Upgrade Phase
        // For example: enable upgrade UI, stop combat logic, etc.
    }

    public void StartCombatPhase()
    {
        CurrentPhase = GamePhase.Combat;
        Debug.Log("Combat phase started.");
        InitializePlayers();
        InitializeCrystals();

        // Add logic specific to the Combat Phase
        // For example: spawn enemies, enable combat logic, etc.
    }

    public void TransitionToNextPhase()
    {
        if (CurrentPhase == GamePhase.Upgrade)
        {
            StartCombatPhase();
        }
        else if (CurrentPhase == GamePhase.Combat)
        {
            StartUpgradePhase();
        }
    }

    private void InitializePlayers() {
        redTeam.Clear();
        blueTeam.Clear();
        foreach (GameObject player in playerList)
        {
            if (player.GetComponent<PlayerClass>().GetTeam() == teamName.red)
            {
                redTeam.Add(player);
                player.GetComponent<PlayerClass>().Respawn(redSpawnPoint, 0);
            }
            if (player.GetComponent<PlayerClass>().GetTeam() == teamName.blue)
            {
                blueTeam.Add(player);
                player.GetComponent<PlayerClass>().Respawn(blueSpawnPoint, 0);
            }
            redTeam.Add(player);
        }
    }
    public void AddPlayer(GameObject player)
    {
        playerList.Add(player);
    }

    public void PlayerDie(GameObject player)  ////DO THISS NEEEEEEEEEEEEEEEEXT just redo
    {
        player.SetActive(false);
        if (player.GetComponent<PlayerClass>().GetTeam() == teamName.red)
        {
            if (redCanSpawn)
            {
                player.GetComponent<PlayerClass>().Respawn(redSpawnPoint, 5);
            }
            else
            {
                redTeam.Remove(player);
                if (redTeam.Count == 0)
                {
                    blueScore += 1;
                    TransitionToNextPhase();
                }
            }
        }
        if (player.GetComponent<PlayerClass>().GetTeam() == teamName.blue)
        {
            if (blueCanSpawn)
            {
                player.GetComponent<PlayerClass>().Respawn(blueSpawnPoint, 5);
            }
            else
            {
                blueTeam.Remove(player);
                if (blueTeam.Count == 0)
                {
                    redScore += 1;
                    TransitionToNextPhase();
                }
            }
        }
    }

    private void InitializeCrystals()
    {
        redCrystals.Clear();
        blueCrystals.Clear();
        redCanSpawn = true; blueCanSpawn = true;
        foreach (GameObject c in crystalList)
        {
            if (c.GetComponent<CrystalScript>().GetTeam() == teamName.red)
            {
                redCrystals.Add(c);
            }
            if (c.GetComponent<CrystalScript>().GetTeam() == teamName.blue)
            {
                blueCrystals.Add(c);
            }
            c.GetComponent<CrystalScript>().Spawn();
        }

    }

    public void AddCrystal(GameObject crystal)
    {
        crystalList.Add(crystal);
    }

    public void DestroyCrystal(GameObject crystal)
    {
        crystal.SetActive(false);
        if (crystal.GetComponent<CrystalScript>().GetTeam() == teamName.red)
        {
            redTeam.Remove(crystal);
            if (redTeam.Count == 0)
            {
                redCanSpawn = false;
            }
        }
        if (crystal.GetComponent<CrystalScript>().GetTeam() == teamName.blue)
        {
            blueTeam.Remove(crystal);
            if (blueTeam.Count == 0)
            {
                blueCanSpawn = false;
            }
        }
    }

    public teamName AssignTeam(GameObject player)
    {
        if (redTeam.Count <= blueTeam.Count)
        {
            redTeam.Add(player);
            return teamName.red;
        }
        else
        {
            blueTeam.Add(player);
            return teamName.blue;
        }
    }
}
