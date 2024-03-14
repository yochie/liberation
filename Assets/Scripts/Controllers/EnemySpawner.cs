using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D spawnZone;

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

    private void Start()
    {
        ellapsedSinceLastSpawn = 0;
        ellapsedSinceLastSpawnRateIncrement = 0;

        this.currentSpawnRate = startingSpawnRatePerSecond;
    }

    private void Update()
    {
        //spawn at current rate
        if(ellapsedSinceLastSpawn > 1f / currentSpawnRate)
        {
            this.Spawn();
            this.ellapsedSinceLastSpawn = 0;
        }
        else
        {
            this.ellapsedSinceLastSpawn += Time.deltaTime;
        }

        //increment spawn rate
        if (ellapsedSinceLastSpawnRateIncrement > spawnRateIncrementLapse)
        {
            this.currentSpawnRate++;
            this.ellapsedSinceLastSpawnRateIncrement = 0;
        }
        else
        {
            this.ellapsedSinceLastSpawnRateIncrement += Time.deltaTime;
        }
    }

    private void Spawn()
    {
        Vector3 spawnPosition = this.RandomPositionOnCollider(this.spawnZone);
        Instantiate(this.toSpawn, spawnPosition, Quaternion.identity, this.transform);
    }

    private Vector3 RandomPositionOnCollider(Collider2D collider)
    {
        float x = UnityEngine.Random.Range(collider.bounds.min.x, collider.bounds.max.x);
        float y = UnityEngine.Random.Range(collider.bounds.min.y, collider.bounds.max.y);        
        return new Vector3(x, y);
    }
}
