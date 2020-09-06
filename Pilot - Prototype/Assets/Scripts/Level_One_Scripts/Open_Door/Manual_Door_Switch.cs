using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manual_Door_Switch : MonoBehaviour
{
    public Animator ani;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetButtonDown("Fire3"))
            {
                ani.SetTrigger("Open");
            }
        }
    }
}
