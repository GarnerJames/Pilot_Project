using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight_Guard_Trigger : MonoBehaviour
{
    public GameObject flashlight;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == ("Player"))
        {
            flashlight.SetActive(true);
        }
    }
}
