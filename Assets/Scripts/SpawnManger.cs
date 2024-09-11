using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public int enemyOnGame;
    public int waveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyOnGame = FindObjectsOfType<EnemyScript>().Length;
        if(enemyOnGame == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
        
        
    }

    void SpawnEnemyWave(int enemyCount)
    {

        for (int i = 0; i < enemyCount; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosz = Random.Range(-10, 11);
        float spawnPosx = Random.Range(-11, 11);
        Vector3 randomPos = new Vector3(spawnPosx, 0, spawnPosz);

        return randomPos;
    }
}
