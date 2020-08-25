using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fiel_Cabnet_Pull : MonoBehaviour
{
    public Animator ani;

    public GameObject player;
    public AudioSource falling;

    public Vector3 playerLocation;
    public Vector3 playerRotation;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetButton("Fire3"))
        {
            ani.SetTrigger("Fall");
            Invoke("PlayAudio", 0.7f);
            player.transform.position = playerLocation;
            player.transform.localScale = playerRotation;
        }
    }

    void PlayAudio()
    {
        falling.Play();
    }

}
