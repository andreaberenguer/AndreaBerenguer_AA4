using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Audio;



public class PlayerController : MonoBehaviour
{
    
    // properties of rigidbody (the sphere)
    private Rigidbody rb;
    private float movementX, movementY;
    AudioSource[] audioSource;
    float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponents<AudioSource>();
    }

    void FixedUpdate() 
    {
        rb.AddForce(new Vector3(movementX, 0.0f, movementY) * speed);
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.magnitude>0.1f && !audioSource[0].isPlaying){
        audioSource[0].Play();
        }
        else if(rb.velocity.magnitude < 0.1f && audioSource[0].isPlaying){
            audioSource[0].Stop();
        }
        audioSource[0].pitch = rb.velocity.magnitude/2;
        

    }

    void OnMove(InputValue movementValue) 
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x; 
        movementY = movementVector.y;
    }
     private void OnCollisionEnter(Collision collision)
    {
        audioSource[1].Play();
    }
}
