using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHealth;
    private int enemyHealthMax = 100;

    public Vector3 enemyVector;
    public Transform enemyTransform;
    public GameObject healthPickupPrefab;

    public TextMeshProUGUI coinCount;
    private int coinScore = 0;

    private void Start()
    {
        enemyHealth = enemyHealthMax;
        coinScore = 0;
    }

    private void Update()
    {
        if (enemyHealth > 100)
        {
            enemyHealth = enemyHealthMax;
        }

        if (enemyHealth <= 0)
        {
            coinScore += 10;
            coinCount.text = (coinScore).ToString();

            Destroy(gameObject);
            SpawnHealthPickup();
        }   
    }

    private void SpawnHealthPickup()
    {
        GameObject healthPickup = Instantiate(healthPickupPrefab) as GameObject;
        healthPickup.transform.position = enemyTransform.position;
    }

}
