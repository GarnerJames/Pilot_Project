using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End_Trigger : MonoBehaviour
{
    public GameObject player;
    public GameObject farCam;
    public Animator playerAni;
    public Animator platform;
    public AudioSource button;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetButtonDown("Fire3"))
            {
                player.GetComponent<PlayerController>().canMove = false;
                player.transform.parent = transform;
                farCam.SetActive(true);
                playerAni.SetFloat("Speed", 0f);
                platform.SetTrigger("Move");
                button.Play();
            }
        }
    }
}
