using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hatch_shade_trig : MonoBehaviour
{
    public Animator shade;
    public GameObject hatchTrig;
    public GameObject button;
    public Material buttonOn;
    public AudioSource music;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetButton("Fire3"))
        {
            shade.SetTrigger("Open");
            hatchTrig.SetActive(true);
            button.GetComponent<MeshRenderer>().material = buttonOn;
            music.Play();
            gameObject.SetActive(false);
        }
    }
}
