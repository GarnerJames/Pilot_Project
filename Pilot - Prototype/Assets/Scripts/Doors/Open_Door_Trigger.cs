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
            door.SetBool("Open", true);
            doorOpen.Play();
            Invoke("Close", 4f);
            //gameObject.SetActive(false);
        }
    }

    void Close()
    {
        door.SetBool("Open", false);
    }
}
