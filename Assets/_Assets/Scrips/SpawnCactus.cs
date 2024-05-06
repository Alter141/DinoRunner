using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCactus : MonoBehaviour
{
    private GameObject cactusSpawn;
    [SerializeField] private List<GameObject> spawnedObjects;
    public float spawnTime = 2f;
    private float spawnCount;

    private void Awake()
    {   
        spawnCount = spawnTime;
    }

    private void Update()
    {
        if (spawnCount >= spawnTime) 
        {
            Spawn();
            spawnCount = 0; 
        }
        spawnCount += Time.deltaTime;
    }

    public void Spawn()
    {
        int ran = Random.Range(0, spawnedObjects.Count);
        if(ran == 9|| ran == 8) 
        {
             cactusSpawn = Instantiate(spawnedObjects[ran], new Vector3(20f,Random.Range(-2.2f, 1f), 0), Quaternion.identity);
        }
        else
        {
            cactusSpawn = Instantiate(spawnedObjects[ran], new Vector3(20f, -2.1f, 0), Quaternion.identity);
            Destroy(cactusSpawn, 3f);
        }
    }
}
