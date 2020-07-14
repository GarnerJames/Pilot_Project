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

                if (sprinting && (Input.GetKeyDown(KeyCode.DownArrow)))
                {
                    animator.SetTrigger("Slide");
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

            }

            //Sprinting
            if (Input.GetKeyDown(KeyCode.LeftShift) && canSprint)
            {
                sprinting = true;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                sprinting = false;
                animator.SetBool("running", false);
            }

            //Sneaking 
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                sneaking = true;
                canSprint = false;
                controller.height = 2f;
                controller.center = new Vector3(0, -0.24f, 0);
            }

            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                sneaking = false;
                canJump = true;
                canSprint = true;
                animator.SetBool("sneaking", false);
                controller.height = 3.4f;
                controller.center = new Vector3(0, 0.6f, 0);
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

        if (other.tag == ("Balance"))
        {
            animator.SetBool("Balance", true);
            canJump = false;
        }

        if (other.tag == ("Die"))
        {
            Die();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == ("Gravity"))
        {
            gravityScale = 0.9f;
        }

        if (other.tag == ("Balance"))
        {
            animator.SetBool("Balance", false);
            canJump = true;
        }

    }

}
