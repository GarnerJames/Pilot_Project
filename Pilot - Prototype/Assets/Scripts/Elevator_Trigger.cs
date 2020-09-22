using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator_Trigger : MonoBehaviour
{
    public GameObject Player;
    public Animator elevator;
    public float elevatorMoveTime;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetButtonDown("Fire3"))
            {
                elevator.SetTrigger("Down");
                Player.GetComponent<PlayerController>().canMove = false;
                Invoke("Move", elevatorMoveTime);
            }
        }
    }

    void Move()
    {
        Player.GetComponent<PlayerController>().canMove = true;
    }
}
