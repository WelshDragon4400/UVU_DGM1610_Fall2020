using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    public bool hasHealth;
    public bool hasItem;
    public float itemCount = 0f;
    
    //health system
    public float playerHealth = 5f;
    
    //attack system
    private GameObject enemy;
    private Rigidbody enemyRB;
    public float bounce = 2f;
    
    //text
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI itemText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI youWinText;

    
    // Start is called before the first frame update
    void Start()
    {
        
        playerRB = GetComponent<Rigidbody>();
        gameOverText.gameObject.SetActive(false);
        youWinText.gameObject.SetActive(false);

       // GameOver(); 
        // UpdateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
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
        //if player hits an item
       /* if (other.CompareTag("Powerup"))
        {
            //you have the powerup and the object is destroyed
            hasPowerUp = true;
            Debug.Log("PowerUp =" + hasPowerUp);
            Destroy(other.gameObject);
        }*/
        
        if (other.CompareTag("Health"))
        {
            //you have the health and the object is destroyed
            hasHealth = true;
            Debug.Log("Health =" + hasHealth);
            Destroy(other.gameObject);
            playerHealth = playerHealth + 0.5f;
            
            //update UI counter
            healthText.text = "Health: " + playerHealth;
            Debug.Log("Health =" + playerHealth);
        }
        
        if (other.CompareTag("Item"))
        {
            //you have the item and the object is destroyed
            hasItem = true;
            Debug.Log("Item =" + hasItem);
            Destroy(other.gameObject);
            itemCount = itemCount + 1f;
            
            //update UI counter
            itemText.text = "Item: " + itemCount;
            Debug.Log("Item =" + itemCount);
        }

        //if hit an enemy
        if (other.CompareTag("Enemy"))
        {
            //display and update health count
            Debug.Log("Collision: -1");
            playerHealth = playerHealth - 0.5f;
            
            //update UI counter
            healthText.text = "Health: " + playerHealth;
            Debug.Log("Health =" + playerHealth);
        }

        //if health is gone
       /* if (playerHealth < 0.5f)
        {
            //game over
            Debug.Log("Game Over!");
            gameOverText.gameObject.SetActive(true);
            Time.timeScale = 0;
        }*/
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

   /* void UpdateHealth(int scoreToAdd)
    {
        playerHealth += scoreToAdd;
        healthText.text = "Health: " + playerHealth;
    }*/
   void GameOver()
   {
       //if health is gone
       if (playerHealth < 0.5f)
       {
           //game over
           Debug.Log("Game Over!");
           gameOverText.gameObject.SetActive(true);
           Time.timeScale = 0;
       }

       if (itemCount > 9f)
       {
           //you win
           Debug.Log("You win!");
           youWinText.gameObject.SetActive(true);
           Time.timeScale = 0;
       }
       
       if (itemCount < 10f)

       {
           youWinText.gameObject.SetActive(false);
       }

   }




}
