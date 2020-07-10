using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AITrigger : MonoBehaviour
{

    public NavMeshAgent ai;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && PlayerController.sneaking == false)
        {
            ai.enabled = true;
        }
    }
}
