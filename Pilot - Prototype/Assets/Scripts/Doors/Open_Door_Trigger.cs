using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Door_Trigger : MonoBehaviour
{
    public Animator door;
    public AudioSource doorOpen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            door.SetTrigger("Open");
            doorOpen.Play();
            gameObject.SetActive(false);
        }
    }
}
