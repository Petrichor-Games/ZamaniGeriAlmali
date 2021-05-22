using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="LevelChunkData")]
public class LevelChunkData : ScriptableObject
{
    public Vector2 chunkSize = new Vector2(10f, 10f);
    public GameObject[] LevelChunks;
}
