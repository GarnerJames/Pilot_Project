using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamBreakTrigger : MonoBehaviour
{

    Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ani.SetBool("Break", true);
        }
    }
}
