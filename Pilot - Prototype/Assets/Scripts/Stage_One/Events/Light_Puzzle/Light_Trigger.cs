using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Trigger : MonoBehaviour
{
    public GameObject spotLight;

    public bool On;

    private void Update()
    {
        if (spotLight.active)
        {
            On= true;
            Invoke("LightsOff", 1.5f);
        }

        if (spotLight.active == false)
        {
            On = false;
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
}
