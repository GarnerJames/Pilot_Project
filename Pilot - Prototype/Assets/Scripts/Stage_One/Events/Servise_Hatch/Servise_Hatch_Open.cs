using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Servise_Hatch_Open : MonoBehaviour
{
    public Animator ani;

    public GameObject player;
    public Vector3 playerLocation;
    public Vector3 playerRotation;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetButton("Fire3"))
        {
            ani.SetTrigger("Open");
            player.transform.position = playerLocation;
            player.transform.localScale = playerRotation;
        }
    }
}
