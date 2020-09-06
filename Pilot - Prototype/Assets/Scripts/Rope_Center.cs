using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope_Center : MonoBehaviour
{
    public GameObject player;
    public float zPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.transform.position = new Vector3(0, player.transform.position.y, zPos);
        }
    }
}
