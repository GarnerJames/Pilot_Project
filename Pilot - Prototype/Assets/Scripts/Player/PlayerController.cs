using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float runSpeed;
    public float sprintSpeed;
    public float sneakSpeed;
    public float jumpHeight;
    public float gravityScale;

    public CharacterController controller;

    Animator animator;

    private Vector3 moveDirection;

    public bool sneaking = false;
    public bool sprinting = false;
    public bool falling = false;
    public bool jumping = false;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        controller.enabled = true;
        animator = GetComponent<Animator>();
        animator.enabled = true;
    }

    
    void Update()
    {

        if (controller.isGrounded)
        {

            moveDirection = new Vector3(0, moveDirection.y, Input.GetAxis("Horizontal") * runSpeed);

            if (sneaking == true)
            {
                moveDirection = new Vector3(0, moveDirection.y, Input.GetAxis("Horizontal") * sneakSpeed);
                animator.SetBool("sneaking", true);
            }

            if (sprinting == true)
            {
                moveDirection = new Vector3(0, moveDirection.y, Input.GetAxis("Horizontal") * sprintSpeed);
                animator.SetBool("running", true);
            }

            moveDirection.y = 0f;

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                moveDirection.y = jumpHeight;
                animator.SetTrigger("Jump");
            }

            falling = false;
            jumping = false;

        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);

        animator.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Horizontal"))));


        if (controller.velocity.y < -0.5f)
        {
            falling = true;
        }

        if (controller.velocity.y > 0.5f)
        {
            jumping = true;
        }

        if (!falling && !jumping)
        {
            if (Input.GetAxis("Horizontal") != -1 && Input.GetAxis("Horizontal") != 1)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    transform.localScale = new Vector3(1, 1, -1);
                }

                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }
        }

        if (falling)
        {
            animator.SetBool("Falling", true);
        }
        else
        {
            animator.SetBool("Falling", false);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == ("Gravity"))
        {
            gravityScale = 0.2f;
        }

        if (other.tag == ("Sneak"))
        {
            sneaking = true;
        }

        if (other.tag == ("Sprint"))
        {
            sprinting = true;
        }

        if (other.tag == ("Ragdoll"))
        {
            animator.enabled = false;
            controller.enabled = false;
        }

        if (other.tag == ("Balance"))
        {
            animator.SetBool("Balance", true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == ("Gravity"))
        {
            gravityScale = 0.9f;
        }

        if (other.tag == ("Sneak"))
        {
            sneaking = false;
            animator.SetBool("sneaking", false);
        }

        if (other.tag == ("Sprint"))
        {
            sprinting = false;
            animator.SetBool("running", false);
        }

        if (other.tag == ("Balance"))
        {
            animator.SetBool("Balance", false);
        }
    }

}
