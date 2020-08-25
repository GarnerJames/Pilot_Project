using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Upper_Door : MonoBehaviour
{
    public GameObject unlockLight;
    public GameObject door;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetButtonDown("Fire3"))
        {
            door.SetActive(false);
            
        }
    }
}
