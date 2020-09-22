using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Up_Gun : MonoBehaviour
{
    public GameObject player;
    public GameObject gun;
    public Animator player_ani;

    public float delayTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PickUp();
        }
    }

    void PickUp()
    {
        player.GetComponent<PlayerController>().canMove = false;
        player_ani.SetTrigger("PickUp");
        Invoke("End", delayTime);
        gun.SetActive(false);
    }

    void End()
    {
        player.GetComponent<PlayerController>().canMove = true;
        gameObject.SetActive(false);
    }
}
