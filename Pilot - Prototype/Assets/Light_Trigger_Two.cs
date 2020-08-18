using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Trigger_Two : MonoBehaviour
{
    public GameObject spotLight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //kill
        }
    }
}
