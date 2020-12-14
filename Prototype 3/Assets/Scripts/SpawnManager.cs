using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject barrierPrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);

    private float startDelay = 2;
    
    private float repeatRate = 2;
    private PlayerController playerControllerScript; 

    // Start is called before the first frame update
    void Start()
    {
        //spawn obstacles at intervals
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        
        //get player controller script
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        //if the game is not over, keep spawning obstacles
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(barrierPrefab, spawnPos, barrierPrefab.transform.rotation);
        }
    }
    
}
