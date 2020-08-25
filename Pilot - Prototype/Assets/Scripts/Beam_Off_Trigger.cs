using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam_Off_Trigger : MonoBehaviour
{
    public GameObject beam;

    public GameObject button;

    public Material pressedColour;

    public AudioSource switchSound;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetButtonDown("Fire3"))
        {
            beam.SetActive(false);
            button.GetComponent<MeshRenderer>().material = pressedColour;
        }
    }

}
