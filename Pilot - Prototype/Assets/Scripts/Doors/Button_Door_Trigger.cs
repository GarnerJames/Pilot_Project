using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Door_Trigger : MonoBehaviour
{
    public Animator door;
    public AudioSource button;
    public AudioSource door_Open;

    bool canPress = true;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetButtonDown("Fire3") && canPress)
            {
                door.SetTrigger("Open");
                button.Play();
                Invoke("Door", 0.5f);
                canPress = false;
            }
        }
    }

    void Door()
    {
        door_Open.Play();
        //gameObject.SetActive(false);
    }
}
