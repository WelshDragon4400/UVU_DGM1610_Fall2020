using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutofBounds1 : MonoBehaviour
{
    //define boundaries
    public float topBounds = 30f;

    public float lowerBounds = -20f;
    
    void Awake()
    {
        Time.timeScale =1;
    }

    // Update is called once per frame
    void Update()
    {    //top bounds destroy set
        if (transform.position.z > topBounds)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBounds)
        {    //if an animal crosses the lower bounds, freeze the game and display game over
            Debug.Log("GAME OVER");
            Destroy(gameObject);
            Time.timeScale =0;
        }
    }
}
