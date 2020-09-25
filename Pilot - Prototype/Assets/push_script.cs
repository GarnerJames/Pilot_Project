using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class push_script : MonoBehaviour
{

    public GameObject player;
    public Animator ani;
    public bool canPush;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetButtonDown("Fire3") && canPush)
            {
                transform.parent = player.transform;
                player.GetComponent<PlayerController>().canFlip = false;
                player.GetComponent<PlayerController>().canJump = false;
                player.GetComponent<PlayerController>().pushing = true;
                Push();
            }

            if (Input.GetButtonUp("Fire3"))
            {
                transform.parent = null;
                player.GetComponent<PlayerController>().canJump = true;
                player.GetComponent<PlayerController>().canFlip = true;
                player.GetComponent<PlayerController>().pushing = false;
                Stop();
            }
        }
    }

    void Push()
    {
        ani.SetBool("Pushing", true);
    }

    void Stop()
    {
        ani.SetBool("Pushing", false);
    }
}
