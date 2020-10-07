using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wakeup_trig : MonoBehaviour
{
    public GameObject player;
    public Animator playerAni;
    public AudioSource aiVoice;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.GetComponent<PlayerController>().canMove = false;
            playerAni.SetTrigger("Get_Up");
            Invoke("AIVoice", 5f);
        }
    }

    void AIVoice()
    {
        aiVoice.Play();
        player.GetComponent<PlayerController>().canMove = true;
        gameObject.SetActive(false);
    }
}
