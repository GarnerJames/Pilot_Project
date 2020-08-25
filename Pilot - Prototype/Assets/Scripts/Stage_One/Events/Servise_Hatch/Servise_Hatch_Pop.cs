using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Servise_Hatch_Pop : MonoBehaviour
{
    public Animator ani;
    public Animator ladder_ani;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ani.SetTrigger("Open");
            Invoke("Ladder", 1f);
        }
    }

    void Ladder()
    {
        ladder_ani.SetTrigger("Drop");
    }
}
