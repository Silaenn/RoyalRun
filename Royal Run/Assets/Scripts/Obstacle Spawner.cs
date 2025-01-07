using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] float obstaclesSpawnTime = 1f;

    void Start() {
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles(){
         while (true)
    {
        yield return new WaitForSeconds(obstaclesSpawnTime);
        Instantiate(obstaclePrefab, transform.position, Random.rotation);
      }
   }
    
}
