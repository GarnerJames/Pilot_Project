using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{

    public float restTime;
    float downTime;

    Animator elevator;

    bool up = false;

    // Start is called before the first frame update
    void Start()
    {
        elevator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (downTime <= Time.time && up)
        {
            elevator.SetTrigger("On");
            up = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            elevator.SetTrigger("On");
            downTime = Time.time + restTime;
            up = true;
        }
    }
}
