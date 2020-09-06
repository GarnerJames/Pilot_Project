using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_Platform_Trig : MonoBehaviour
{
    public Animator ani;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ani.SetTrigger("Move");
        }
    }
}
