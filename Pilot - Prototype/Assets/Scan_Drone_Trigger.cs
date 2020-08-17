using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scan_Drone_Trigger : MonoBehaviour
{
    public Animator droneAni;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            droneAni.SetTrigger("Move");
        }
    }
}
