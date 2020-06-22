﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float runSpeed;
    public float sprintSpeed;
    public float sneakSpeed;
    public float jumpHeight;
    public float doubleJump;
    public float jumpNumber;
    public float gravityScale;
    public float fallingSpeed;
    public float attackRange = 0.5f;

    public LayerMask enemyLayer;

    public CharacterController controller;

    Animator animator;

    private Vector3 moveDirection;

    public bool sneaking = false;
    public bool sprinting = false;
    public bool falling = false;
    public bool jumping = false;
    public bool canJump = true;
    public bool canAttack = true;

    public Transform attackPoint;


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

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                sneaking = true;
            }
            
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                sneaking = false;
                canJump = true;
                animator.SetBool("sneaking", false);
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                sprinting = true;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                sprinting = false;
                animator.SetBool("running", false);
            }

            if (sprinting && (Input.GetKeyDown(KeyCode.DownArrow)))
            {
                animator.SetTrigger("Slide");
            }

            if (sneaking == true)
            {
                Sneak();
            }

            if (sprinting == true)
            {
                Sprint();
            }

            moveDirection.y = 0f;

            animator.SetBool("Falling", false);

            animator.SetTrigger("Land");

            animator.SetBool("Jumping", false);

            jumpNumber = doubleJump;

            falling = false;
            jumping = false;

            if (Input.GetKeyDown(KeyCode.RightControl) && canAttack)
            {
                Attack();
            }

        }


        if (jumpNumber > 0)
        {
            if (canJump && !falling)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    moveDirection.y = jumpHeight;
                    animator.SetBool("Jumping", true);
                    animator.SetBool("Falling", false);
                    jumpNumber = jumpNumber - 1;
                    falling = false;
                }
            }
        }
       

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);

        animator.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Horizontal"))));


        if (controller.velocity.y < fallingSpeed)
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

        if (transform.position.x != 0)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }

        if (falling)
        {
            animator.SetBool("Falling", true);
        }

    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider [] hitEnemys = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider Enemy in hitEnemys)
        {
            Enemy.GetComponent<EnemyDamage>().TakeDamage();
        }

    }

    private void OnDrawGizmosSelected()
    {

        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void Sneak()
    {
        moveDirection = new Vector3(0, moveDirection.y, Input.GetAxis("Horizontal") * sneakSpeed);
        animator.SetBool("sneaking", true);

        canJump = false;
    }

    void Sprint()
    {
        moveDirection = new Vector3(0, moveDirection.y, Input.GetAxis("Horizontal") * sprintSpeed);
        animator.SetBool("running", true);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == ("Gravity"))
        {
            gravityScale = 0.2f;
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

        if (other.tag == ("Wall"))
        {
            animator.SetBool("Wall", true);
        }

        if (other.tag == ("Slide") && sprinting == true)
        {
            animator.SetTrigger("Slide");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == ("Gravity"))
        {
            gravityScale = 0.9f;
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

        if (other.tag == ("Wall"))
        {
            animator.SetBool("Wall", false);
        }
    }

}
