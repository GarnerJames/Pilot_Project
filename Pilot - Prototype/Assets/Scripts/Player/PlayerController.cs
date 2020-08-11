using System.Collections;
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
    public float attackDelay;

    public GameObject attackFX;
    public GameObject gunTip;

    public LayerMask enemyLayer;

    public CharacterController controller;

    Animator animator;

    private Vector3 moveDirection;

    public static bool sneaking = false;
    public bool sprinting = false;
    public bool falling = false;
    public bool jumping = false;
    public bool canJump = true;
    public bool canAttack = true;
    public bool canSprint = true;
    public bool canMove = true;
    public bool canSlide = true;

    public GameObject gun;

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

        if (canMove)
        {
            if (controller.isGrounded)
            {

                moveDirection = new Vector3(0, moveDirection.y, Input.GetAxis("Horizontal") * runSpeed);


                if (canSlide)
                {
                    if (sprinting && (Input.GetButtonDown("Fire1")))
                    {
                        animator.SetTrigger("Slide");
                        canSlide = false;
                        Invoke("SlideDelay", 2f);
                    }
                }

                //Sneak
                if (sneaking == true)
                {
                    Sneak();
                }

                //Sprint
                if (sprinting == true)
                {
                    Sprint();
                }

                //Reset Y velocity
                moveDirection.y = 0f;

                animator.SetBool("Falling", false);

                animator.SetTrigger("Land");

                animator.SetBool("Jumping", false);

                jumpNumber = doubleJump;

                falling = false;
                jumping = false;

                //Attack 
                if (Input.GetKeyDown(KeyCode.RightControl) && canAttack)
                {
                    Attack();

                }

                if (Input.GetKeyDown(KeyCode.R))
                {
                    Caught();
                }

            }

            //Sprinting
            if (Input.GetButtonDown("Fire2") && canSprint)
            {
                sprinting = true;
            }

            if (Input.GetButtonUp("Fire2"))
            {
                sprinting = false;
                animator.SetBool("running", false);
                
            }

            //Sneaking 
            if (Input.GetButtonDown("Fire1"))
            {
                sneaking = true;
                canSprint = false;
                controller.height = 2f;
                controller.center = new Vector3(0, -0.14f, 0);
                
            }

            if (Input.GetButtonUp("Fire1"))
            {
                sneaking = false;
                canJump = true;
                canSprint = true;
                animator.SetBool("sneaking", false);
                Invoke("JumpColDelay", 0.8f);
                //controller.height = 3.4f;
                //controller.center = new Vector3(0, 0.6f, 0);
            }


            if (jumpNumber > 0)
            {
                if (canJump && !falling)
                {
                    if (Input.GetButtonDown("Jump"))
                    {
                        moveDirection.y = jumpHeight;
                        animator.SetBool("Jumping", true);
                        animator.SetBool("Falling", false);
                        jumpNumber = jumpNumber - 1;
                        falling = false;
                        controller.height = 2f;
                        controller.center = new Vector3(0, 0.8f, 0);
                        Invoke("JumpColDelay", 0.5f);
                    }
                }
            }


            moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
            controller.Move(moveDirection * Time.deltaTime);

            animator.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Horizontal"))));
        }


        if (controller.velocity.y < fallingSpeed)
        {
            falling = true;
            
        }

        if (controller.velocity.y > 0.5f)
        {
            jumping = true;
        }

        //Flip function
        if (canMove)
        {
            if (!jumping)
            {
                if (Input.GetAxis("Horizontal") != -1 && Input.GetAxis("Horizontal") != 1)
                {
                    if (Input.GetAxis("Horizontal") < 0)
                    {
                        transform.localScale = new Vector3(1, 1, -1);

                    }

                    if (Input.GetAxis("Horizontal") > 0)
                    {
                        transform.localScale = new Vector3(1, 1, 1);
                    }
                }
            }
        }

        //Keeps player at 0 on the X axis
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

        canAttack = false;

        canMove = false;

        Invoke("MoveAttackDelay", 0.86f);

        Invoke("AttackDelay", attackDelay);

        Instantiate(attackFX, gunTip.transform.position, gunTip.transform.rotation);

        Collider[] hitEnemy = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);

        foreach(Collider enemy in hitEnemy)
        {
            enemy.GetComponent<EnemyDamage>().TakeDamage();
        }

    }

    void AttackDelay()
    {
        canAttack = true;
    }

    void MoveAttackDelay()
    {
        canMove = true;
    }

    void SlideDelay()
    {
        canSlide = true;
    }

    void JumpColDelay()
    {
        controller.height = 3.4f;
        controller.center = new Vector3(0, 0.6f, 0);
    }

    void Caught()
    {
        animator.SetTrigger("Caught");
        canMove = false;
        //restart
    }

    //Attack point drawer
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
        sneaking = false;
    }

    public void Die()
    {
        animator.enabled = false;
        controller.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == ("Gravity"))
        {
            gravityScale = 0.2f;
        }

        if (other.tag == ("Ragdoll"))
        {
            animator.enabled = false;
            controller.enabled = false;
        }

        if (other.tag == ("Die"))
        {
            Die();
        }

        if (other.tag == "GunTrigger")
        {
            gun.SetActive(true);
            canAttack = true;
        }

       

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == ("Gravity"))
        {
            gravityScale = 0.9f;
        }

        

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Push_Truck" && Input.GetButtonDown("Fire3"))
        {
            animator.SetTrigger("Push_Truck");
            canMove = false;
            animator.SetFloat("Speed", 0);
            Invoke("CanMove", 4.5f);
        }
    }

    void CanMove()
    {
        canMove = true;
    }

}
