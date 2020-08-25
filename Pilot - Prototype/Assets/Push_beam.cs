using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push_beam : MonoBehaviour
{
    public Animator ani;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetButtonDown("Fire3"))
        {
            ani.SetTrigger("Push");
        }
    }
}
