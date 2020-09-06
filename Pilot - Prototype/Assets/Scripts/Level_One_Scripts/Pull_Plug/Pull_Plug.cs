using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pull_Plug : MonoBehaviour
{

    public Animator largeDoor;
    public Animator smallDoor;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetButtonDown("Fire3"))
            {
                largeDoor.SetTrigger("Open");
                smallDoor.SetTrigger("Close");
                //lights off
                //alarm
            }
        }
    }
}
