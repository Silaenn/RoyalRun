using System.Collections.Generic;
using UnityEngine;

public class LevelGeneretor : MonoBehaviour
{
    [Header("References")]
    [SerializeField] CameraController cameraController;
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] Transform chunckParent;
    [SerializeField] ScoreManager scoreManager;

    [Header("Level Settings")]
    [Tooltip("The amount of chunks we start with")]
    [SerializeField] int startingChunksAmount = 12;
    [Tooltip("Do not change chunk length value unless chunk prefab size reflects change")]
    [SerializeField] float chunkLength = 10f;
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float minMoveSpeed = 2f;
    [SerializeField] float maxMoveSpeed = 20f;
    [SerializeField] float minGravityZ = -22f;
    [SerializeField] float maxGravityZ = -2f;
    List<GameObject> chunks = new List<GameObject>();

    void Start()
    {
        SpawnStartingChunks();
    }

    void Update(){
        MoveChunks();
    }

    public void ChangeChunkMoveSpeed(float speedAmount){
        float newMoveSpeed = moveSpeed + speedAmount;
        newMoveSpeed = Mathf.Clamp(newMoveSpeed, minMoveSpeed, maxMoveSpeed);

        if (newMoveSpeed != moveSpeed)
        {
            moveSpeed = newMoveSpeed;

            float newGravityZ = Physics.gravity.z - speedAmount;
            newGravityZ = Mathf.Clamp(newGravityZ, minGravityZ, maxGravityZ);

            Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, newGravityZ);
            cameraController.ChangeCameraFOV(speedAmount);
        }
    }

    void SpawnStartingChunks()
    {
        for (int i = 0; i < startingChunksAmount; i++)
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
        float spawnPositionZ = CalculateSpawnPositionZ();
        Vector3 chunkSpawnPos = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);
        GameObject newChunkGO = Instantiate(chunkPrefab, chunkSpawnPos, Quaternion.identity, chunckParent);

        chunks.Add(newChunkGO);
        Chunk newChunk = newChunkGO.GetComponent<Chunk>();
        newChunk.Init(this, scoreManager);
    }

    float CalculateSpawnPositionZ()
    {
        float spawnPositionZ;

        if (chunks.Count == 0)
        {
            spawnPositionZ = transform.position.z;
        }
        else
        {
            spawnPositionZ = chunks[chunks.Count - 1].transform.position.z + chunkLength;
        }

        return spawnPositionZ;
    }

    void MoveChunks() {
        for (int i = 0; i < chunks.Count; i++)
        {
           GameObject chunk = chunks[i]; 
           chunks[i].transform.Translate(-transform.forward * (moveSpeed * Time.deltaTime));

           if (chunk.transform.position.z <= Camera.main.transform.position.z - chunkLength) {
              chunks.Remove(chunk);
              Destroy(chunk);
              SpawnChunk();
           }
        }
    }
}
