using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D spawnZone;

    [SerializeField]
    private Transform spawnToParent;

    [SerializeField]
    private float minDistanceFromPlayer;

    [SerializeField]
    private float spawnInterval;

    [SerializeField]
    private float spawnRatePerSecond;

    [SerializeField]
    private GameObject toSpawn;

    private float ellapsedSinceLastSpawn;

    private Transform playerTransform;

    private void Start()
    {
        ellapsedSinceLastSpawn = 0;
        this.playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        //spawn at current rate
        //spawns in batches at fixed intervals, batch size is determined by spawn rate
        if (ellapsedSinceLastSpawn > this.spawnInterval)
        {
            float batchSize = this.spawnInterval * this.spawnRatePerSecond;
            for (int i = 0; i < batchSize; i++)
            {
                Spawner.SpawnAtRandomPositionOnCollider(this.toSpawn, this.spawnZone, this.playerTransform.position, this.minDistanceFromPlayer, this.spawnToParent);
            }
            this.ellapsedSinceLastSpawn -= spawnInterval;
        }
        else
        {
            this.ellapsedSinceLastSpawn += Time.deltaTime;
        }
    }

    private static void SpawnAtRandomPositionOnCollider(GameObject toSpawn, Collider2D onCollider, Vector3 avoidPosition, float minDistance, Transform parent)
    {
        Vector3 spawnPosition;
        do {
            spawnPosition = Spawner.RandomPositionOnCollider(onCollider);
        } while ((spawnPosition - avoidPosition).magnitude < minDistance);
        Instantiate(toSpawn, spawnPosition, Quaternion.identity, parent);
    }

    private static Vector3 RandomPositionOnCollider(Collider2D collider)
    {
        float x = UnityEngine.Random.Range(collider.bounds.min.x, collider.bounds.max.x);
        float y = UnityEngine.Random.Range(collider.bounds.min.y, collider.bounds.max.y);        
        return new Vector3(x, y);
    }

    public float GetSpawnRate()
    {
        return this.spawnRatePerSecond;
    }

    internal void SetSpawnRate(float rate)
    {
        this.spawnRatePerSecond = rate;
    }
}
