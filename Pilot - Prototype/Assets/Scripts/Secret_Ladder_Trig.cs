using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secret_Ladder_Trig : MonoBehaviour
{
    public Animator ladder;
    public Animator hatch;
    public GameObject blackImage;
    public GameObject topLight;
    public AudioSource aiVoice;
    public float audioTime;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (Input.GetButtonDown("Fire3"))
            {
                aiVoice.Play();
                Invoke("PowerOut", audioTime);
            }
        }
    }

    void PowerOut()
    {
        blackImage.SetActive(true);
        Invoke("PowerOn", 2f);
    }

    void PowerOn()
    {
        blackImage.SetActive(false);
        topLight.GetComponent<Flicker_Light>().enabled = true;
        Invoke("Ladder", 1f);
    }

    void Ladder()
    {
        hatch.SetTrigger("Open");
        ladder.SetTrigger("Down");
    }
}
