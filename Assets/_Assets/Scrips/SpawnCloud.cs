using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCloud : MonoBehaviour
{
    [SerializeField] private GameObject clound;
    private float spawnTime = 1.8f;
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
        GameObject cloudSpawn = Instantiate(clound, new Vector3(10f, Random.Range(01f, 4.3f), 0), Quaternion.identity);
        Destroy(cloudSpawn, 15f);
    }
}
