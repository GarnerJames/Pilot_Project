using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class large_cube_switch_trig : MonoBehaviour
{
    public Animator door;
    public Animator switchAni;
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
                switchAni.SetTrigger("Down");
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
