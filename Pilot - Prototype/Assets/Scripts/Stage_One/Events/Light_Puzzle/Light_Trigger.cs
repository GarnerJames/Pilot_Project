using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Trigger : MonoBehaviour
{
    public GameObject spotLight;

    public AudioSource laserSound;

    public bool On;

    private void Update()
    {
        if (spotLight.activeInHierarchy)
        {
            On = true;
            laserSound.Play();
            Invoke("LightsOff", 1.5f);
        }

        if (spotLight.activeInHierarchy == false)
        {
            On = false;
            laserSound.Stop();
            Invoke("LightsOn", 2f);
        }
    }

    void LightsOff()
    {
        spotLight.SetActive(false);
    }

    void LightsOn()
    {
        spotLight.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (On)
            {
                GameObject.Find("Player").GetComponent<PlayerController>().Die();
            }
        }
    }
}
