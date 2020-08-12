using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck_Push_Trigger : MonoBehaviour
{

    public Animator truck;
    public GameObject break_wall;
    public GameObject player;
    public Vector3 playerLocation;
    public Vector3 playerRotation;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetButtonDown("Fire3"))
        {
            truck.SetTrigger("Push");
            break_wall.SetActive(false);
            player.transform.position = playerLocation;
            player.transform.localScale = playerRotation;
            gameObject.SetActive(false);
        }
    }
}
