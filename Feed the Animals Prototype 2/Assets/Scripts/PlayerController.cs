using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

//player input and speed
{ public float horizontalInput;
public float speed = 10f;

//range of player motion
public float xRange = 20f;

//define the food as projectile
public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      horizontalInput = Input. GetAxis("Horizontal");
      //adding movement
      transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
      //setting up left boundary
      if(transform.position.x < -xRange)
	{
	transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
	}
      //setting up right boundary
      if(transform.position.x > xRange)
	{
	transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
	}
		// launch the food
      if (Input.GetKeyDown(KeyCode.Space))
      {
	      Instantiate(projectile, transform.position, projectile.transform.rotation);
      }
      
      
    }
}
