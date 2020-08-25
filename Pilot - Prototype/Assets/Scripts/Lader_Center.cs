using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lader_Center : MonoBehaviour
{
    public GameObject player;
    public float zPos;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && Input.GetButtonDown("Fire3"))
        {
            player.transform.position = new Vector3(0, player.transform.position.y, zPos);
        }
    }
}
