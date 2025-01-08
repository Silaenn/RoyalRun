 using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstaclePrefabs;
    [SerializeField] float obstaclesSpawnTime = 1f;
    [SerializeField] Transform obstacleParent;
    [SerializeField] float spawnWidth = 4f;

    void Start() {
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles(){
         while (true)
    {
        GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnWidth, spawnWidth), transform.position.y, transform.position.z);
        yield return new WaitForSeconds(obstaclesSpawnTime);
        Instantiate(obstaclePrefab, spawnPosition, Random.rotation, obstacleParent);
      }
   }
    
}
