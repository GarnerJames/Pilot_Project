using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chase_start : MonoBehaviour
{
    public GameObject roller;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            roller.GetComponent<AI>().chase = true;
        }
    }
}
