using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secret_Ladder_Trig : MonoBehaviour
{
    public Animator ladder;
    public Animator hatch;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (Input.GetButtonDown("Fire3"))
            {
                hatch.SetTrigger("Open");
                ladder.SetTrigger("Down");
            }
        }
    }

}
