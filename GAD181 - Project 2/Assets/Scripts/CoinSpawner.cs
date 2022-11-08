using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public float SpawningTime;
    public GameObject ToSpawn1, ToSpawn2, ToSpawn3, ToSpawn4;
    public int pickObject;

    void Start()
    {
        ///timer set random between 4.0f and 9.0f///
        SpawningTime = Random.Range(5.0f, 10.0f);
    }

    ///Depending on pickObject number an object is spawned///
    void SpawnNow()
    {
        if (pickObject == 1)
        {
            Instantiate(ToSpawn1, new Vector3(Random.Range(0f, -23f), Random.Range(0.5f, 0.5f), Random.Range(0f, -16f)), Quaternion.identity);

        }
        if (pickObject == 2)
        {
            Instantiate(ToSpawn2, new Vector3(Random.Range(0f, -23f), Random.Range(0.5f, 0.5f), Random.Range(0f, -16f)), Quaternion.identity);

        }
        if (pickObject == 3)
        {
            Instantiate(ToSpawn3, new Vector3(Random.Range(0f, -23f), Random.Range(0.5f, 0.5f), Random.Range(0f, -16f)), Quaternion.identity);

        }
        if (pickObject == 4)
        {
            Instantiate(ToSpawn4, new Vector3(Random.Range(0f, -23f), Random.Range(0.5f, 0.5f), Random.Range(0f, -16f)), Quaternion.identity);

        }
    }

    ///Spawntime runs down to 0 than it sets the pickupObject random between 1 and 5 and ///
    ///calls the spawnNow function. Then it resets the spawntime. ///
    void Update()
    {
        SpawningTime -= Time.deltaTime;
        if (SpawningTime <= 0)
        {
            pickObject = Random.Range(1, 5);
            SpawnNow();
            SpawningTime = Random.Range(5.0f, 10.0f);
        }
    }
}
