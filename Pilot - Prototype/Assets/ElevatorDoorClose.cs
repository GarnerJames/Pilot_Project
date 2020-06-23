using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoorClose : MonoBehaviour
{

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetTrigger("Close");
        }
    }
}
