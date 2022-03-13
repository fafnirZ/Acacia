using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> mobsToSpawn;
    [SerializeField] private Vector2 spawnRangeX, spawnRangeY;
    [SerializeField] float spawnRate = 5f;
    [SerializeField] int maxMobCount = 5;

    void Start(){
        
        InvokeRepeating("SpawnMobs", 1, spawnRate);
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(spawnRangeX.x, spawnRangeX.y);
        float spawnPosY = Random.Range(spawnRangeY.x, spawnRangeY.y);
        Vector3 randomPos = new Vector3(spawnPosX, spawnPosY, 0);
        return randomPos;
    }
    private GameObject RandomMob(){
        GameObject randomMob = mobsToSpawn[Random.Range(0,mobsToSpawn.Count)];
        return randomMob;
    }

    void SpawnMobs(){
        int mobCount = FindObjectsOfType<Enemy>().Length;

        if (mobCount < maxMobCount){
            for (int i = 0; i < maxMobCount - mobCount; i++)
                Instantiate(RandomMob(), GenerateSpawnPosition(), RandomMob().transform.rotation);
        }
        else return;
    }
}
