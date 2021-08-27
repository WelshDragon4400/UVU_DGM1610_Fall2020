using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 20f;

    public float turnSpeed = 45f;

    public float horizontalInput;

    public float forwardInput;
   
    // Update is called once per frame
    void Update()
    {
        //get axis variables
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        
        //move player forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        //rotate player
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }
}
