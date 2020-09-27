using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starting_Doors_Trigger : MonoBehaviour
{

    public Animator leftDoor;
    public Animator rightDoor;
    public float delayTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Invoke("Doors", delayTime);
        }
    }

    void Doors()
    {
        leftDoor.SetBool("Open", true);
        rightDoor.SetBool("Open", true);
        //play sound
    }
}
