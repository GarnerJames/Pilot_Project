using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide_Door_Trigger : MonoBehaviour
{
    public Animator door;
    public AudioSource doorOpen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            door.SetBool("Open", true);
            doorOpen.Play();
            //gameObject.SetActive(false);
        }
    }
}
