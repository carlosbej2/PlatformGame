using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

Rigidbody rb;

[SerializeField] float movementSpeed = 7f;
[SerializeField] float jumpValue = 7f;
[SerializeField] float rotation = 90f;
[SerializeField] bool rotating;

[SerializeField] Transform groundCheck;
[SerializeField] LayerMask ground;

[SerializeField] AudioSource jumpS;

     IEnumerator RotateMe(Vector3 byAngles, float inTime)
     {
         var fromAngle = transform.rotation;
         var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
         for (var t = 0f; t <= 1; t += Time.deltaTime / inTime)
         {
             transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
           
             yield return null;
         }
 
         transform.rotation = toAngle;
         rotating = false;
     }

    //este script sirve para la transición de giro, es un script cogido de internet, NO lo hemos hecho nosotros.


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }


    void Update()
    {

        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(HorizontalInput * movementSpeed, rb.velocity.y, VerticalInput * movementSpeed);

        if (Input.GetButtonDown("Jump") && IsGrounded()){ 
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && IsGrounded()){
            movementSpeed = 12f;
            rb.velocity = new Vector3(HorizontalInput * movementSpeed, rb.velocity.y, VerticalInput * movementSpeed);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) && IsGrounded()){
            movementSpeed = 7f;
            rb.velocity = new Vector3(HorizontalInput * movementSpeed, rb.velocity.y, VerticalInput * movementSpeed);
        }

        if (Input.GetKeyDown("e") && !rotating)
             {
                 rotating = true;
                 StartCoroutine(RotateMe(Vector3.up * 90, 0.8f));
             }

        if (Input.GetKeyDown("q") && !rotating)
             {
                 rotating = true;
                 StartCoroutine(RotateMe(Vector3.up * -90, 0.8f));
             }

  

    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Enemy Head")){
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
     }


    void Jump(){
        rb.velocity = new Vector3(rb.velocity.x, jumpValue, rb.velocity.z);
        jumpS.Play();
    }

    bool IsGrounded(){

        return Physics.CheckSphere(groundCheck.position, 0.1f, ground);
        
    }


    /* private void FixedUpdate(){

    }
    */

  

    //https://answers.unity.com/questions/930557/rotate-an-object-90-degrees-on-a-button-press.html
}
