using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D spawnZone;

    [SerializeField]
    private float minDistanceFromPlayer;

    [SerializeField]
    private float spawnBatchAfterDelay;

    [SerializeField]
    private float startingSpawnRatePerSecond;

    [SerializeField]
    private GameObject toSpawn;

    [SerializeField]
    private float spawnRateIncrementLapse;

    [SerializeField]
    private float spawnRateIncrements;

    [SerializeField]
    private float spawnRateCap;

    private float ellapsedSinceLastSpawn;
    private float ellapsedSinceLastSpawnRateIncrement;

    private float currentSpawnRate;

    private Transform playerTransform;

    private void Start()
    {
        ellapsedSinceLastSpawn = 0;
        ellapsedSinceLastSpawnRateIncrement = 0;

        this.currentSpawnRate = startingSpawnRatePerSecond;
        this.playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }

    private void Update()
    {
        //spawn at current rate
        //spawns in batches at fixed intervals, batch size is determined by spawn rate
        if (ellapsedSinceLastSpawn > this.spawnBatchAfterDelay)
        {
            float batchSize = this.spawnBatchAfterDelay * currentSpawnRate;
            for (int i = 0; i < batchSize; i++)
            {
                this.Spawn();
            }
            this.ellapsedSinceLastSpawn -= spawnBatchAfterDelay;
        }
        else
        {
            this.ellapsedSinceLastSpawn += Time.deltaTime;
        }

        //increment spawn rate
        if (ellapsedSinceLastSpawnRateIncrement > spawnRateIncrementLapse && currentSpawnRate < spawnRateCap)
        {
            this.currentSpawnRate++;
            this.ellapsedSinceLastSpawnRateIncrement -= spawnRateIncrementLapse;
        }
        else
        {
            this.ellapsedSinceLastSpawnRateIncrement += Time.deltaTime;
        }
    }

    private void Spawn()
    {
        Vector3 playerPosition = this.playerTransform.position;
        Vector3 spawnPosition;
        do {
            spawnPosition = this.RandomPositionOnCollider(this.spawnZone);
        } while ((spawnPosition - playerPosition).magnitude < this.minDistanceFromPlayer);
        Instantiate(this.toSpawn, spawnPosition, Quaternion.identity, this.transform);
    }

    private Vector3 RandomPositionOnCollider(Collider2D collider)
    {
        float x = UnityEngine.Random.Range(collider.bounds.min.x, collider.bounds.max.x);
        float y = UnityEngine.Random.Range(collider.bounds.min.y, collider.bounds.max.y);        
        return new Vector3(x, y);
    }
}
