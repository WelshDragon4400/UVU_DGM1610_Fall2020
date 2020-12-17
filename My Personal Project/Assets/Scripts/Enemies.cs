using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemies : MonoBehaviour
{
    
    public float speed = 10.0f;
    private Rigidbody enemyRB;
    private GameObject player;
    public float distanceToChase = 10f;

	//health system
    public float enemyHealth = 5f;

   	//text
    public TextMeshProUGUI healthTextE;

    
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
       // healthTextE.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        //if distance between enemy and player positions is less than chase distance
        if (Vector3.Distance(transform.position, player.transform.position) < distanceToChase)
       {
           //chase 
           enemyRB.AddForce((player.transform.position - transform.position).normalized * speed);
       }
    }


    private void OnTriggerEnter(Collider other)
	{
	//if hit sword
        if (other.CompareTag("Sword"))
        {
            //display and update health count
            Debug.Log("Stab: -0.5");
            enemyHealth = enemyHealth - 1f;
            
            //update UI counter
            healthTextE.text = "0" + enemyHealth;
            //Debug.Log("Health =" + playerHealth);
        }
	//if health is gone
       if (enemyHealth < 0.5f)
       {
           //destroy object
           Destroy(gameObject);
       }
	}
}
