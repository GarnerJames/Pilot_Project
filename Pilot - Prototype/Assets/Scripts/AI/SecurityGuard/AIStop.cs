using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIStop : MonoBehaviour
{

    public NavMeshAgent security;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            security.enabled = false;
        }
    }
}
