using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquishWall : MonoBehaviour
{

    Animator squish;

    

    // Start is called before the first frame update
    void Start()
    {
        squish = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            squish.SetTrigger("go");
            
        }
    }
}
