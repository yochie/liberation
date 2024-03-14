using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpriteSwapper : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> prefabs;

    [SerializeField]
    private float swapDuration;

    private float timeUntilNextSwap;

    private GameObject spawnedPrefab;

    private int spawnedPrefabIndex;

    // Start is called before the first frame update
    void Start()
    {
        this.timeUntilNextSwap = 0;
        this.spawnedPrefabIndex = -1;
    }

    // Update is called once per frame
    void Update()
    {
        this.timeUntilNextSwap -= Time.deltaTime;
        if(this.timeUntilNextSwap <= 0)
        {
            this.timeUntilNextSwap = this.swapDuration;
            if(this.spawnedPrefab != null)
                Destroy(this.spawnedPrefab);
            this.spawnedPrefabIndex = (this.spawnedPrefabIndex + 1) % this.prefabs.Count;
            GameObject toSpawn = prefabs[this.spawnedPrefabIndex];
            this.spawnedPrefab = Instantiate(toSpawn, this.transform.position, Quaternion.identity);
        }
        
    }
}
