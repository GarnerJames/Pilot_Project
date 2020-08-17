using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Servise_Hatch_Pop : MonoBehaviour
{
    public Animator ani;
    public GameObject openTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ani.SetTrigger("Pop_Open");
            openTrigger.SetActive(true);
        }
    }
}
