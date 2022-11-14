using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private GameObject enemy;
    public Vector3 spawner;

    public float respawnTime = 5;
    private float nextRespawnTime;

    void Update()
    {
        if (enemy == null)
        {
            if (Time.time > nextRespawnTime)
            {
                nextRespawnTime = Time.time + respawnTime;

                enemy = Instantiate(enemyPrefab) as GameObject;
                enemy.transform.position = spawner;
            }
        }
    }
}
