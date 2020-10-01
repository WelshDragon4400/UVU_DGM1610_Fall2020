using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    public int animalIndex;
    public float spawnRangeX = 20.5f;
    public float spawnPosZ = 20.5f;

    // Update is called once per frame
    void Update()
    {//when a key is pressed, animals will spawn
        if (Input.GetKeyDown(KeyCode.S))
        {//randomly generate animals in random places
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            int animalIndex = Random.Range(0,animalPrefabs.Length);
            Debug.Log(animalIndex);
            Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
        } 
    }
}
