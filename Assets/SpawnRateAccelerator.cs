using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRateAccelerator : MonoBehaviour
{
    [SerializeField]
    private Spawner spawner;

    [SerializeField]
    private float spawnRateIncrementIntervals;

    [SerializeField]
    private float spawnRateIncrements;

    [SerializeField]
    private float spawnRateCap;

    private float currentSpawnRate;
    private float ellapsedSinceLastSpawnRateIncrement;

    // Start is called before the first frame update
    void Start()
    {
        ellapsedSinceLastSpawnRateIncrement = 0;
        this.currentSpawnRate = spawner.GetSpawnRate();
    }

    // Update is called once per frame
    void Update()
    {
        //increment spawn rate
        if (ellapsedSinceLastSpawnRateIncrement > spawnRateIncrementIntervals && currentSpawnRate < spawnRateCap)
        {
            this.currentSpawnRate++;
            this.ellapsedSinceLastSpawnRateIncrement -= spawnRateIncrementIntervals;
        }
        else
        {
            this.ellapsedSinceLastSpawnRateIncrement += Time.deltaTime;
        }

        this.spawner.SetSpawnRate(this.currentSpawnRate);
    }
}
