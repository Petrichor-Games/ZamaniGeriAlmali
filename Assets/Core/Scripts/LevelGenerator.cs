using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public LevelChunkData[] LevelChunkData;
    public LevelChunkData[] LevelChunkData2;
    public LevelChunkData[] LevelChunkData3;
    public LevelChunkData FirstChunk;
    private LevelChunkData previousChunk;
    public Vector3 spawnOrigin;
    private Vector3 spawnPosition;
    public int chunkstospawn = 10;
    private int chunkCount = 0;
    public GameObject OyunSonuBolumu;

    void OnEnable()
    {
        TriggerExit.OnChunkExited += PickAndSpawnChunk;
    }

    private void OnDisable()
    {
        TriggerExit.OnChunkExited -= PickAndSpawnChunk;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            PickAndSpawnChunk();
            
        }
    }

    void Start()
    {
        previousChunk = FirstChunk;

        for (int i = 0; i < chunkstospawn; i++)
        {
            PickAndSpawnChunk();
            
        }

        
    }

   

    LevelChunkData PickNextChunk(LevelChunkData[] LCD)
    {
        List<LevelChunkData> allowedChunkList = LCD.ToList();
        LevelChunkData nextChunk = null;

        spawnPosition = spawnPosition + new Vector3(0f, 0, previousChunk.chunkSize.y);

        nextChunk = LCD[Random.Range(0, allowedChunkList.Count)];

        return nextChunk;
    }

    void PickAndSpawnChunk()
    {
        //Debug.Log(chunkCount);
         if (chunkCount==55)
         {
             
             LevelChunkData chunkToSpawn2 = PickNextChunk(LevelChunkData2);

             GameObject objectFromChunk2 = chunkToSpawn2.LevelChunks[Random.Range(0, chunkToSpawn2.LevelChunks.Length)];
             previousChunk = chunkToSpawn2;
             var asd2 = Instantiate(objectFromChunk2, spawnPosition + spawnOrigin, objectFromChunk2.transform.rotation);
             chunkCount++;

             SpawnCoins(asd2);
         }
         else if (chunkCount>110)
         {
             LevelChunkData chunkToSpawn2 = PickNextChunk(LevelChunkData3);

             GameObject objectFromChunk2 = chunkToSpawn2.LevelChunks[Random.Range(0, chunkToSpawn2.LevelChunks.Length)];
             previousChunk = chunkToSpawn2;
             var asd2 = Instantiate(objectFromChunk2, spawnPosition + spawnOrigin, objectFromChunk2.transform.rotation);
             chunkCount++;

             SpawnCoins(asd2);
         }
        
        LevelChunkData chunkToSpawn = PickNextChunk(LevelChunkData);

        GameObject objectFromChunk = chunkToSpawn.LevelChunks[Random.Range(0, chunkToSpawn.LevelChunks.Length)];
        previousChunk = chunkToSpawn;
        var asd = Instantiate(objectFromChunk, spawnPosition + spawnOrigin, objectFromChunk.transform.rotation);
        chunkCount++;

        SpawnCoins(asd);

    }

    public void UpdateSpawnOrigin(Vector3 originDelta)
    {
        spawnOrigin = spawnOrigin + originDelta;
    }

    public GameObject coinPrefab;

    void SpawnCoins(GameObject asd)
    {
        int coinsToSpawn = 5;
        for (int i = 0; i< coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab,asd.transform);
            temp.transform.position = GetRandomPointInCollider(asd.GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );

        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }


}
