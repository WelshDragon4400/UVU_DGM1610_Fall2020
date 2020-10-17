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
        //get forward and horizontal axis for variables
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        
        //move the vehicle forward based on vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        //rotates the car based on horizontal input
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }
}
