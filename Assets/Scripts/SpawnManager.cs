using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    //public GameObject[] gunsPrefabs;

    public int waveNumber = 1;
    public int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWaves(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            //  Debug.Log("hussain");     
            waveNumber++;
            SpawnEnemyWaves(waveNumber);

        }
    }
    void SpawnEnemyWaves(int enemyToSpawn)
    {
        for (int i = 0; i < enemyToSpawn; i++)
        {
            float spawnPosX = Random.Range(-8, 8);
            float spawnPosZ = Random.Range(-8, 8);
            Vector3 randomPos = new Vector3(spawnPosX, transform.position.y + 1, spawnPosZ);

            int randomEnemy = Random.Range(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[randomEnemy], randomPos, enemyPrefab[randomEnemy].transform.rotation);

        }
    }
    //void spawnGuns()
    //{
    //    for (int i = 0; i <= 4; i++)
    //    {
    //        Instantiate(gunsPrefabs[0])
    //    }
    //}
}
