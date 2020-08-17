using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinning_Con_Stop : MonoBehaviour
{
    public Animator ani;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetButtonDown("Fire3"))
        {
            ani.SetTrigger("Stop");
        }
    }
}
