using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Light_Trigger : MonoBehaviour
{
    public GameObject roomLight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            roomLight.SetActive(true);
        }
    }
}
