using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsolUpgrade : UpgradeBase
{
    public GameObject ballPrefab;  // Prefab of the ball
    public int numberOfBalls = 2;  // Number of circling balls
    public float radius = 10f;      // Distance from the player
    public float rotationSpeed = 5f;  // Speed of the rotation

    private GameObject[] balls;

    void Start()
    {
        upgradeType = UpgradeType.damage;
        ballPrefab = Resources.Load<GameObject>("Prefabs/AsolBalls");
        effectValue = 10f;
        balls = new GameObject[numberOfBalls];

        for (int i = 0; i < numberOfBalls; i++)
        {
            float angle = i * Mathf.PI * 2f / numberOfBalls;
            Vector3 position = transform.position + new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius);
            balls[i] = Instantiate(ballPrefab, position, Quaternion.identity, transform);
            balls[i].AddComponent<DamageOnCollision>().damageAmount = effectValue;
        }
    }

    void Update()
    {
        for (int i = 0; i < numberOfBalls; i++)
        {
            float angle = Time.time * rotationSpeed + i * Mathf.PI * 2f / numberOfBalls;
            Vector3 offset = new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius);
            balls[i].transform.position = transform.position + offset;
        }
    }
}
