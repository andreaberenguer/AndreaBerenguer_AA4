using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMovimiento : MonoBehaviour
{
    Rigidbody rb;
    AudioSource[] audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponents<AudioSource>();
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
    private void OnCollisionEnter(Collision collision)
    {
        audioSource[1].Play();
    }

}
