using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator_Trigger : MonoBehaviour
{

    public GameObject lightOne;
    public GameObject guard;
    public GameObject guardLightTrigger;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetButtonDown("Fire3"))
        {
            lightOne.SetActive(false);
            guard.SetActive(false);
            guardLightTrigger.SetActive(false);
        }
    }
}
