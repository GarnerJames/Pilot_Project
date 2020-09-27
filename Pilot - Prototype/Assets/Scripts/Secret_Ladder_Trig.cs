using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secret_Ladder_Trig : MonoBehaviour
{
    public Animator ladder;
    public Animator hatch;
    public GameObject blackImage;
    public GameObject ambientAudio;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (Input.GetButtonDown("Fire3"))
            {
                PowerOut();
            }
        }
    }

    void PowerOut()
    {
        blackImage.SetActive(true);
        ambientAudio.GetComponent<AudioSource>().enabled = false;
        Invoke("PowerOn", 4f);
    }

    void PowerOn()
    {
        blackImage.SetActive(false);
        ambientAudio.GetComponent<AudioSource>().enabled = true;
        Invoke("Ladder", 2f);
    }

    void Ladder()
    {
        hatch.SetTrigger("Open");
        ladder.SetTrigger("Down");
    }
}
