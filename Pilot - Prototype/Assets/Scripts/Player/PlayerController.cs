using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float runSpeed;
    public float climbSpeed;
    public float climbRopeSpeed;
    public float sprintSpeed;
    public float pushSpeed;
    public float sneakSpeed;
    public float jumpHeight;
    public float doubleJump;
    public float jumpNumber;
    public float gravityScale;
    public float fallingSpeed;
    public float fallingStunSpeed;
    public float fallingKillSpeed;
    public float attackRange = 0.5f;
    public float attackDelay;

    public float yVel;

    public float currentZpos;

    public GameObject attackFX;
    public GameObject gunTip;
    public GameObject pushScript;

    public LayerMask enemyLayer;

    public CharacterController controller;

    Animator animator;
    public Animator death_ani;

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
    public bool sliding = false;
    public bool autoSneaking = false;
    public bool climbing = false;
    public bool climbingRope = false;
    public bool canFlip = true;
    public bool pushing;

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

        currentZpos = transform.position.z;
        yVel = controller.velocity.y;

        if (climbing == true)
        {
            Climb();
        }

        if (climbingRope == true)
        {
            ClimbRope();
        }

        if (!climbing && !climbingRope)
        {
            gravityScale = 1.2f;
        }

        if (canMove)
        {
            if (!climbing && !climbingRope)
            {
                moveDirection = new Vector3(0, moveDirection.y, Input.GetAxis("Horizontal") * runSpeed);
            }

            if (pushing)
            {
                moveDirection = new Vector3(0, moveDirection.y, Input.GetAxis("Horizontal") * pushSpeed);
            }

            //Sprinting
            if (Input.GetButtonDown("Fire2") && canSprint && !climbing && !climbingRope)
            {
                sprinting = true;
            }

            if (Input.GetButtonUp("Fire2"))
            {
                sprinting = false;
                animator.SetBool("running", false);

            }

            //Sprint
            if (sprinting == true)
            {
                Sprint();
            }

            if (sprinting == false)
            {
                pushScript.GetComponent<push_script>().canPush = true;
            }

            


            if (controller.isGrounded)
            {

                

                if (canSlide)
                {
                    if (sprinting)
                    {
                        if (Input.GetButtonDown("Fire1"))
                        {
                            animator.SetTrigger("Slide");
                            sliding = true;
                            canJump = false;
                            controller.height = 1f;
                            controller.center = new Vector3(0, -0.57f, 0);
                            canSlide = false;
                            Invoke("SlideDelay", 1f);
                        }
                    }
                }

                
                //Sneak
                if (sneaking == true)
                {
                    Sneak();
                }

                //Reset Y velocity
                moveDirection.y = 0f;

                animator.SetBool("Falling", false);

                

                //land

                animator.SetBool("Jumping", false);

                jumpNumber = doubleJump;

                falling = false;
                jumping = false;

                //Attack 
                if (Input.GetButtonDown("Fire4") && canAttack)
                {
                    Attack();

                }

                if (controller.velocity.y > fallingStunSpeed)
                {
                    animator.SetTrigger("Land");
                }
                else
                {
                    animator.ResetTrigger("Land");
                }

                if (controller.velocity.y < fallingKillSpeed)
                {
                    Die();
                }

                if (controller.velocity.y < fallingStunSpeed)
                {
                    animator.SetTrigger("Roll");
                }
                else
                {
                    animator.ResetTrigger("Roll");
                }

            }

            //Sneaking 
            if (autoSneaking == false)
            {
                if (Input.GetButtonDown("Fire1") && !sliding && !climbing && !climbingRope)
                {
                    sneaking = true;
                    canSprint = false;
                    controller.height = 2f;
                    controller.center = new Vector3(0, -0.06f, 0);
                }

                if (Input.GetButtonUp("Fire1") && !sliding)
                {
                    sneaking = false;
                    canJump = true;
                    canSprint = true;
                    pushScript.GetComponent<push_script>().canPush = true;
                    animator.SetBool("sneaking", false);
                    controller.height = 3.2f;
                    controller.center = new Vector3(0, 0.46f, 0);
                }
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

            if (!climbing && !climbingRope)
            {
                animator.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Horizontal"))));
            }
            
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
        if (canMove && canFlip)
        {
            if (transform.position.z < currentZpos)
            {
                transform.localScale = new Vector3(1, 1, -1);
            }

            if (gameObject.transform.position.z > currentZpos)
            {
                transform.localScale = new Vector3(1, 1, 1);
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

        Invoke("MoveAttackDelay", 0.8f);

        Invoke("AttackDelay", attackDelay);

        Instantiate(attackFX, gunTip.transform.position, gunTip.transform.rotation);

        Collider[] hitEnemy = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);

        foreach(Collider enemy in hitEnemy)
        {
            enemy.GetComponent<EnemyDamage>().TakeDamage();
        }

    }

    void Climb()
    {
        gravityScale = 0f;
        moveDirection = new Vector3(0, Input.GetAxis("Vertical") * climbSpeed, 0);
        
        canJump = true;
        transform.localScale = new Vector3(1, 1, 1);
        animator.SetBool("Climbing", true);

        animator.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical"))));

        if (Input.GetButton("Jump"))
        {
            climbing = false;
            animator.SetBool("Climbing", false);
        }
    }

    void ClimbRope()
    {
        gravityScale = 0f;
        moveDirection = new Vector3(0, Input.GetAxis("Vertical") * climbRopeSpeed, 0);

        canJump = true;
        //transform.localScale = new Vector3(1, 1, 1);
        animator.SetBool("ClimbingRope", true);

        animator.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical"))));

        if (Input.GetButton("Jump"))
        {
            climbingRope = false;
            animator.SetBool("ClimbingRope", false);
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
        controller.height = 3.2f;
        controller.center = new Vector3(0, 0.46f, 0);
        sliding = false;
        canSlide = true;
        canJump = true;
    }

    void JumpColDelay()
    {
        controller.height = 3.2f;
        controller.center = new Vector3(0, 0.46f, 0);
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

        if (!climbing && !climbingRope && !pushing)
        {
            moveDirection = new Vector3(0, moveDirection.y, Input.GetAxis("Horizontal") * sneakSpeed);
            animator.SetBool("sneaking", true);
            canJump = false;
            pushScript.GetComponent<push_script>().canPush = false;
        }
        
    }

    void Sprint()
    {

        if (!climbing && !climbingRope && !pushing)
        {
            moveDirection = new Vector3(0, moveDirection.y, Input.GetAxis("Horizontal") * sprintSpeed);
            animator.SetBool("running", true);
            sneaking = false;
            pushScript.GetComponent<push_script>().canPush = false;
        }
        
    }

    void AutoSneak()
    {

        autoSneaking = true;
        sneaking = true;
        canSprint = false;
        sprinting = false;
        controller.height = 2f;
        controller.center = new Vector3(0, -0.06f, 0);
    }

    public void Die()
    {
        animator.enabled = false;
        canMove = false;
        controller.enabled = false;
        death_ani.SetTrigger("Death_Fade");
        Invoke("Respawn", 4f);
    }

    void Respawn()
    {
        GameObject.Find("Player").GetComponent<Checkpoints>().Reload();
        death_ani.ResetTrigger("Death_Fade");
        canMove = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == ("Gravity"))
        {
            gravityScale = 0.2f;
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

        if (other.tag == "AutoSneak")
        {
            AutoSneak();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == ("Gravity"))
        {
            gravityScale = 1f;
        }

        if (other.tag == "AutoSneak")
        {
            autoSneaking = false;
            sneaking = false;
            canJump = true;
            canSprint = true;
            animator.SetBool("sneaking", false);
            controller.height = 3.2f;
            controller.center = new Vector3(0, 0.46f, 0);
        }

        if (other.tag == "Climb")
        {
            climbing = false;
            animator.SetBool("Climbing", false);
        }

        if (other.tag == "Rope")
        {
            climbingRope = false;
            animator.SetBool("ClimbingRope", false);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Climb")
        {
            if (Input.GetButtonDown("Fire3"))
            {
                climbing = true;
            }
        }


        if (other.tag == "Rope")
        {
            if (Input.GetButtonDown("Fire3"))
            {
                climbingRope = true;
            }
        }

    }

    void CanMove()
    {
        canMove = true;
    }

}
