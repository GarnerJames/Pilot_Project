using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{

    Rigidbody rb;

    public float runSpeed;
    public float crouchSpeed;
    public float jumpHeight;

    public LayerMask groundLayer;

    public Transform groundCheck;

    float groundCheckRadius = 0.2f;

    bool facingRight;
    bool grounded = false;

    Collider[] groundCollision;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

   
    void Update()
    {
       
    }

    void FixedUpdate()
    {

        if (grounded && Input.GetAxis("Jump") > 0)
        {
            rb.AddForce(new Vector3(0, jumpHeight, 0)); 
        }

        groundCollision = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, groundLayer);
        if (groundCollision.Length > 0) grounded = true;
        else grounded = false;

        float move = Input.GetAxis("Horizontal");

        float crouching = Input.GetAxisRaw("Fire3");

        if (crouching > 0)
        {
            rb.velocity = new Vector3(move * crouchSpeed, rb.velocity.y, 0);
        }
        else
        {
            rb.velocity = new Vector3(move * runSpeed, rb.velocity.y, 0);
        }

        if (move > 0 && !facingRight) Flip();
        else if (move < 0 && facingRight) Flip();
    } 

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.z *= -1;
        transform.localScale = theScale;
    }
}
