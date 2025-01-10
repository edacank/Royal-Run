using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstaclePrefabs;
    [SerializeField] float obstacleSpawnTime = 1f;
    //int obstacleSpawned = 0;
    [SerializeField] Transform obstacleParent;
    [SerializeField] float spawnWidth = 4f;
    void Start()
    {
        StartCoroutine(SpawnObstacleRoutine());
    }

    IEnumerator SpawnObstacleRoutine()
    {
        while(true)
        {
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnWidth,+spawnWidth), transform.position.y,transform.position.z);
            yield return new WaitForSeconds(obstacleSpawnTime);
        Instantiate(obstaclePrefab,transform.position,Random.rotation,obstacleParent);
      //  obstacleSpawned++;
        }
    }
}
