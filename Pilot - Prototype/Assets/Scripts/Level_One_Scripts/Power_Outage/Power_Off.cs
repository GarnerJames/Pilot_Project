using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_Off : MonoBehaviour
{
    public GameObject blackScreen;
    public GameObject ladder;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            blackScreen.SetActive(true);
            ladder.SetActive(true);
            player.GetComponent<PlayerController>().canMove = false;
            //Play Sound
            Invoke("PowerOn", 3f);

        }
    }

    void PowerOn()
    {
        blackScreen.SetActive(false);
        //Play Sound
        player.GetComponent<PlayerController>().canMove = true;
        Destroy(gameObject);
    }
}
