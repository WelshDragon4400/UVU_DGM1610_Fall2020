using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        //initialize 
        startPos = transform.position; 
       
        //initialize and gets only half of the background
        repeatWidth = GetComponent<BoxCollider>().size.x/2;
    }

    // Update is called once per frame
    void Update()
    {
        //if the x position is less than startPos.x - repeatWidth, transform the position to startPos
        if(transform.position.x < startPos.x - repeatWidth) 
        { 
            //go back to startPos
            transform.position = startPos; 
        }    
    }
}
