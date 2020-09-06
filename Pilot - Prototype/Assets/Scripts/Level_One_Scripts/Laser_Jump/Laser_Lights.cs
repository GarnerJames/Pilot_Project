using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Lights : MonoBehaviour
{
    public GameObject lights;
    public GameObject player;

    private void Update()
    {
        if (lights.activeInHierarchy)
        {
            Invoke("LightOff", 3f);
        }

        if (lights.activeInHierarchy == false)
        {
            Invoke("LightOn", 3f);
        }
    }

    void LightOff()
    {
        lights.SetActive(false);
    }

    void LightOn()
    {
        lights.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (lights.activeInHierarchy)
            {
                player.GetComponent<PlayerController>().Die();
            }
        }
    }
}
