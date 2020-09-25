using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attach_Player : MonoBehaviour
{
    public GameObject player;
    public float time;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = transform;
            player.GetComponent<PlayerController>().canMove = false;
            Invoke("Done", time);
        }
    }

    void Done()
    {
        player.GetComponent<PlayerController>().canMove = true;
        player.transform.parent = null;
        gameObject.SetActive(false);
    }
}
