using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {    //destroy balls when they collide with animals
        Destroy(gameObject);
        
    }
}
