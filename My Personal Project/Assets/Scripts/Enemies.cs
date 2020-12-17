using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    
    public float speed = 10.0f;
    private Rigidbody enemyRB;
    private GameObject player;
    public float distanceToChase = 10f;
   
    
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
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
}
