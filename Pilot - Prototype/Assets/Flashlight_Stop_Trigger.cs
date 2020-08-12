using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight_Stop_Trigger : MonoBehaviour
{
    public GameObject flashlight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            Invoke("Flashlight_Stop", 3f);
        }
    }

    void Flashlight_Stop()
    {
        flashlight.SetActive(false);
    }
}
