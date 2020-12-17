using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //player movement
    public float speed = 10.0f;
    private Rigidbody playerRB;
    public float turnSpeed = 45f;
    public float horizontalInput;
    public float forwardInput;
    
    //powerups
    public bool hasPowerUp;
    
    //health system
    public float playerHealth = 5f;
    
    //attack system
    private GameObject enemy;
    private Rigidbody enemyRB;
    public float bounce = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //get forward and horizontal axis for variables
            horizontalInput = Input.GetAxis("Horizontal");
            forwardInput = Input.GetAxis("Vertical");
        
            //move the player forward based on vertical input
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            //rotates the player based on horizontal input
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //if player hits a powerup
        if (other.CompareTag("Powerup"))
        {
            //you have the powerup and the object is destroyed
            hasPowerUp = true;
            Debug.Log("PowerUp =" + hasPowerUp);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Enemy"))
        {
            //display and update health count
            Debug.Log("Collision: -1");
            playerHealth = playerHealth - 0.5f;
            Debug.Log("Health =" + playerHealth);  
        }
    }



    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //bounce the enemy away a little
            Debug.Log("Pow!");
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            enemyRigidbody.AddForce(awayFromPlayer * bounce, ForceMode.Impulse);
        }

    }








}
