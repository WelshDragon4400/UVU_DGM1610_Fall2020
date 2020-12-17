using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] puPrefabs;
    public GameObject[] enemyPrefabs;
    public int powerupIndex;
    public int enemyIndex;

    public float spawnRange = 85.0f;
    public float startDelay;
    public float spawnIntervalP;
    public float spawnIntervalE;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPowerUps", startDelay, spawnIntervalP); 
        InvokeRepeating("SpawnEnemies", startDelay, spawnIntervalE); 

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnPowerUps()
    {
        //Randomly generate powerups at a random location
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRange, spawnRange), 2, Random.Range(-spawnRange, spawnRange));
        int powerupIndex = Random.Range(0,puPrefabs.Length);
        Instantiate(puPrefabs[powerupIndex], spawnPos, puPrefabs[powerupIndex].transform.rotation);
        
    }
    void SpawnEnemies()
    {
        //Randomly generate enemies at a random location
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRange, spawnRange), 2, Random.Range(-spawnRange, spawnRange));
        int enemyIndex = Random.Range(0,enemyPrefabs.Length);
        Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
        
    }
}
