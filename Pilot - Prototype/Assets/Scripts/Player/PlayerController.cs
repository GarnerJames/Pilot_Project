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

    public CapsuleCollider col;

    public CharacterController controller;
    Animator ani;

    private Vector3 moveDirection;

    public bool sneaking = false;
    public bool sprinting = false;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        controller.enabled = true;

        ani = GetComponent<Animator>();
        ani.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

        moveDirection = new Vector3(Input.GetAxis("Horizontal") * runSpeed, moveDirection.y, 0);

        if (sneaking == true)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal") * sneakSpeed, moveDirection.y, 0);
            ani.SetBool("sneaking", true);
        }

        if (sprinting == true)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal") * sprintSpeed, moveDirection.y, 0);
            ani.SetBool("running", true);
        }

        if (controller.isGrounded)
        {

            moveDirection.y = 0f;

            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpHeight;
                ani.SetBool("Jump", true);
            }
            else
            {
                ani.SetBool("Jump", false);
            }
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);

        ani.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Horizontal"))));

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == ("Gravity"))
        {
            gravityScale = 0.1f;
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
            ani.enabled = false;
            controller.enabled = false;
            col.enabled = false;
        }

        if (other.tag == ("Balance"))
        {
            ani.SetBool("Balance", true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == ("Gravity"))
        {
            gravityScale = 1f;
        }

        if (other.tag == ("Sneak"))
        {
            sneaking = false;
            ani.SetBool("sneaking", false);
        }

        if (other.tag == ("Sprint"))
        {
            sprinting = false;
            ani.SetBool("running", false);
        }

        if (other.tag == ("Balance"))
        {
            ani.SetBool("Balance", false);
        }
    }

}
