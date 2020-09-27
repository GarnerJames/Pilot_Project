using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class push_script : MonoBehaviour
{

    public GameObject player;
    public Animator ani;
    public float playerZ;
    public bool canPush;
    public bool pushing;
    public bool pulling;
    public bool moving;

    private void Update()
    {
        playerZ = player.GetComponent<PlayerController>().currentZpos;

        if (moving)
        {
            if (player.transform.position.z > playerZ)
            {
                pushing = true;
                pulling = false;
                Push();
            }

            if (player.transform.position.z < playerZ)
            {
                pushing = false;
                pulling = true;
                Pull();
            }

            if (player.transform.position.z == playerZ)
            {
                Moving();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player")
        {
            if (Input.GetButtonDown("Fire3") && canPush)
            {
                moving = true;
                transform.parent = player.transform;
                player.GetComponent<PlayerController>().canFlip = false;
                player.GetComponent<PlayerController>().canJump = false;
                player.GetComponent<PlayerController>().pushing = true; 
            }

            if (Input.GetButtonUp("Fire3"))
            {
                moving = false;
                transform.parent = null;
                player.GetComponent<PlayerController>().canJump = true;
                player.GetComponent<PlayerController>().canFlip = true;
                player.GetComponent<PlayerController>().pushing = false;
                Stop();
            }
        }
    }

    void Moving()
    {
        ani.SetBool("Pushing", true);
    }

    void Push()
    {
        ani.SetBool("Pushing", true);
        ani.SetBool("Pulling", false);
    }

    void Pull()
    {
        ani.SetBool("Pulling", true);
        ani.SetBool("Pushing", false);
    }

    void Stop()
    {
        ani.SetBool("Pushing", false);
    }
}
