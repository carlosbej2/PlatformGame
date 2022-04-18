using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

Rigidbody rb;    
[SerializeField] float movementSpeed = 7f;
[SerializeField] float jumpValue = 7f;

[SerializeField] Transform groundCheck;
[SerializeField] LayerMask ground;

//private AudioSource audiosource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //audiosource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(HorizontalInput * movementSpeed, rb.velocity.y, VerticalInput * movementSpeed);

        if (Input.GetButtonDown("Jump") && IsGrounded()){ 
            rb.velocity = new Vector3(rb.velocity.x, jumpValue, rb.velocity.z);
        }
            
            //audiosource.Play();

        
    }

    bool IsGrounded(){

        return Physics.CheckSphere(groundCheck.position, 0.1f, ground);
    }


    /* private void FixedUpdate(){

    }
    */

    /*private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == "Enemy"){
            print("Collision");
        } 
    } */
}
