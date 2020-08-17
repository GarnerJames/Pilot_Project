using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Trigger : MonoBehaviour
{
    public GameObject spotLight;

    private void Update()
    {
        if (spotLight.active)
        {
            Invoke("LightsOff", 4f);
        }

        if (spotLight.active == false)
        {
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
