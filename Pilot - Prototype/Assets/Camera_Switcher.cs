using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Switcher : MonoBehaviour
{
    public GameObject activeCam;
    public GameObject deCam;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            activeCam.SetActive(true);
            deCam.SetActive(false);
        }
    }
}
