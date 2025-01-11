using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] GameObject fencePrefab;
    [SerializeField] float[] lanes ={-2.5f, 0f, 2.5f};
    
    void Start()
    {
        SpawnFence();
    }

    void SpawnFence()
    {
        List<int> availableLanes = new List<int> {0,1,2};
        int fencesToSpawn = Random.Range(0,lanes.Length);
        for(int i =0 ; i<fencesToSpawn; i++){
            //lanes.Length --> availableLanes.Count
            int randomLaneIndex =  Random.Range(0, availableLanes.Count);
            int selectedLane = availableLanes[randomLaneIndex];
            availableLanes.RemoveAt(randomLaneIndex);
            //randomLaneIndex -->selectedLane
            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(fencePrefab,spawnPosition,Quaternion.identity, this.transform);
        }
        
    }
}
