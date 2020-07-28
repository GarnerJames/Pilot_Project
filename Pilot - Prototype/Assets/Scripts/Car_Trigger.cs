using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Trigger : MonoBehaviour
{

    public Animator ani;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ani.SetTrigger("Car");
        }
    }
}
