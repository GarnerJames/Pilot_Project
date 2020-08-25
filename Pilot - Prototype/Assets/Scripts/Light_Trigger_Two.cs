using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Trigger_Two : MonoBehaviour
{
    public AudioSource laser_Sound;

    private void Update()
    {
        laser_Sound.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("Player").GetComponent<PlayerController>().Die();
        }
    }
}
