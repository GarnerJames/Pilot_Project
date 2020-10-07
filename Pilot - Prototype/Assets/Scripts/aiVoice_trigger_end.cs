using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiVoice_trigger_end : MonoBehaviour
{
    public AudioSource aiVoice;

    public void voice()
    {
        Invoke("ai", 2f);
    } 

    void ai()
    {
        aiVoice.Play();
    }
}
