using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //movement
    private Rigidbody playerRB;
    public float jumpForce; 
    public float gravityMod; 
    public bool gameOver;
    public bool isGrounded = true;
    
    //animation and particles
    private Animator playerAnim;
    public ParticleSystem explosionParticle; 
    public ParticleSystem dirtParticle; 
    
    //sounds
    public AudioClip jumpSound; 
    public AudioClip crashSound; 
    private AudioSource playerAudio; 
    
    // Start is called before the first frame update
    void Start()
    {
        //access the rigid body
        playerRB = GetComponent<Rigidbody>();

        //get animation component
        playerAnim = GetComponent<Animator>();
        
        //change gravity
        Physics.gravity *= gravityMod;
        
        //get sound component
        playerAudio = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //if the space bar is pressed, the player will jump and make a sound
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !gameOver)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
            isGrounded = false;
            playerAudio.PlayOneShot(jumpSound, 1.0f); 
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop(); 
        } 
    }

    void OnCollisionEnter(Collision collision)
    {
        //if the player collides with the ground, isGrounded is true
        if(collision.gameObject.CompareTag("Ground") && !gameOver) 
        { 
            isGrounded = true; 
            dirtParticle.Play(); 
        } 
        
        //if the player collides with an obstacle, gameOver is true
        else if(collision.gameObject.CompareTag("Obstacle")) 
        {
            Debug.Log("Game Over");
            gameOver = true;
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f); 
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
             
        } 
    }
}
