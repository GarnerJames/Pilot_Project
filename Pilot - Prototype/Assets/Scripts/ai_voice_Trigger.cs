using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ai_voice_Trigger : MonoBehaviour
{
    public AudioSource aiVoice;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            aiVoice.Play();
            gameObject.SetActive(false);
        }
    }
}
