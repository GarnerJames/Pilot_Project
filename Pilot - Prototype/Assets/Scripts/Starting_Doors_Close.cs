using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starting_Doors_Close : MonoBehaviour
{
    public Animator leftDoor;
    public Animator rightDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            leftDoor.SetBool("Close", true);
            rightDoor.SetBool("Close", true);
            //play sound
        }
    }
}
