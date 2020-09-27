using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Off_Switch_Trigger : MonoBehaviour
{
    public Animator doorSwitch;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetButtonDown("Fire3"))
            {
                doorSwitch.SetTrigger("Switch");
                //play sound
            }
        }
    }
}
