using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 10;

    // Update is called once per frame
    void Update()
    {
        // the object will move at a constant rate
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
