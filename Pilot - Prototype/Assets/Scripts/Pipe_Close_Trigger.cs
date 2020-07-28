using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe_Close_Trigger : MonoBehaviour
{
    public Animator ani;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ani.SetTrigger("Close");
        }
    }
}
