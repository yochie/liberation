using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D spawnZone;

    [SerializeField]
    private float spawnDelaySeconds;

    [SerializeField]
    private GameObject toSpawn;    

    private float ellapsedSinceLastSpawn;

    private void Start()
    {
        ellapsedSinceLastSpawn = 0;
    }

    private void Update()
    {
        if(ellapsedSinceLastSpawn > spawnDelaySeconds)
        {
            this.Spawn();
            this.ellapsedSinceLastSpawn = 0;
        }
        else
        {
            this.ellapsedSinceLastSpawn += Time.deltaTime;
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
