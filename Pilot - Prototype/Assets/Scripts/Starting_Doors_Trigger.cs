using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starting_Doors_Trigger : MonoBehaviour
{

    public Animator leftDoor;
    public Animator rightDoor;
    public float delayTime;
    public AudioSource aiHello;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Invoke("Hello", 2f);
            Invoke("Doors", delayTime);
        }
    }

    void Hello()
    {
        aiHello.Play();
    }

    void Doors()
    {
        leftDoor.SetBool("Open", true);
        rightDoor.SetBool("Open", true);
        //play sound
        gameObject.SetActive(false);
    }
}
