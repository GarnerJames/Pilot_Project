using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe_Break_Trig : MonoBehaviour
{
    public Animator ani;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ani.SetTrigger("Break");
        }
    }
}
