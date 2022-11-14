using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinSpawner : MonoBehaviour
{
    public float SpawningTime;
    public GameObject ToSpawn1, ToSpawn2, ToSpawn3, ToSpawn4;
    public int pickObject;

    void Start()
    {
        SpawningTime = Random.Range(5.0f, 10.0f);
    }

    void SpawnNow()
    {
        if (pickObject == 1)
        {
            Instantiate(ToSpawn1, new Vector3(Random.Range(-24f, -3f), Random.Range(0.5f, 0.5f), Random.Range(-24f, -10f)), Quaternion.identity);

        }
        if (pickObject == 2)
        {
            Instantiate(ToSpawn2, new Vector3(Random.Range(-11f, 1f), Random.Range(0.5f, 0.5f), Random.Range(-6f, 3f)), Quaternion.identity);

        }
        if (pickObject == 3)
        {
            Instantiate(ToSpawn3, new Vector3(Random.Range(-25.5f, -20.5f), Random.Range(0.5f, 0.5f), Random.Range(9f, -24f)), Quaternion.identity);

        }
        if (pickObject == 4)
        {
            Instantiate(ToSpawn4, new Vector3(Random.Range(-22f, -1f), Random.Range(0.5f, 0.5f), Random.Range(16f, 4f)), Quaternion.identity);

        }
    }

    void Update()
    {
        SpawningTime -= Time.deltaTime;

        if (SpawningTime <= 0)
        {
            pickObject = Random.Range(1, 4);

            SpawnNow();

            SpawningTime = Random.Range(5.0f, 10.0f);
        }
    }
}
