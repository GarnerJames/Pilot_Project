using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pull_Box_Trigger : MonoBehaviour
{

    public Animator ani;
    public GameObject player;
    public Vector3 position;
    public Vector3 scale;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetButton("Fire3"))
            {
                player.transform.position = position;
                player.transform.localScale = scale;
                ani.SetTrigger("Push"); 
            }
        }
    }
}
