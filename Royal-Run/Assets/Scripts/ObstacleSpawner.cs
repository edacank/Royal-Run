using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] float obstacleSpawnTime = 1f;
    //int obstacleSpawned = 0;
    
    void Start()
    {
        StartCoroutine(SpawnObstacleRoutine());
    }

    IEnumerator SpawnObstacleRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(obstacleSpawnTime);
        Instantiate(obstaclePrefab,transform.position,Random.rotation);
      //  obstacleSpawned++;
        }
    }
}
