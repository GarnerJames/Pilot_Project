using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open_Hatch : MonoBehaviour
{
    public Animator hatch;
    public Animator ladder;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetButtonDown("Fire3"))
            {
                ladder.SetTrigger("Up");
                hatch.SetTrigger("Open");
                //play sound
            }
        }
    }
}
