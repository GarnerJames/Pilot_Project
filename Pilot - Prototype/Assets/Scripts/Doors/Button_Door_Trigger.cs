using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Door_Trigger : MonoBehaviour
{
    public Animator door;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetButtonDown("Fire3"))
            {
                door.SetTrigger("Open");
            }
        }
    }
}
