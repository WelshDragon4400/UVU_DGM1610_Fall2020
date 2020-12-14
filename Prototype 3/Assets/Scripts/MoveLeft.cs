using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

public float speed = 10f;

private PlayerController playerControllerScript; 
private float leftBound = -15f;


    // Start is called before the first frame update
    void Start()
    {
	//get the player controller script
		playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();    
	}



    // Update is called once per frame
    void Update()
    {
	//if the game is not over, keep moving left
        if(playerControllerScript.gameOver == false)
		{ 
			transform.Translate(Vector3.left * Time.deltaTime * speed); 
		} 

	//if an obstacle hits the left bound, destroy it
		if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
		{
			Destroy(gameObject);
		}

    }
}
