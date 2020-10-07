using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Activation : MonoBehaviour
{
    public GameObject switchLight;
    public Material lightOn;
    public GameObject onSwitchTrigger;
    public GameObject offSwitchTrigger;
    public AudioSource button;


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetButton("Fire3"))
            {
                onSwitchTrigger.SetActive(true);
                offSwitchTrigger.SetActive(false);
                switchLight.GetComponent<MeshRenderer>().material = lightOn;
                button.Play();
            }
        }
    }
}
