using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator_Trigger : MonoBehaviour
{

    public GameObject lightOne;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetButtonDown("Fire3"))
        {
            lightOne.SetActive(false);
        }
    }
}
