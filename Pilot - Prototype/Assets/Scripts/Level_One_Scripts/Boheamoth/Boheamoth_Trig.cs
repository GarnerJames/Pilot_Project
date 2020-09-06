using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boheamoth_Trig : MonoBehaviour
{

    public GameObject boheamoth;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (boheamoth.GetComponent<AI>().chase == false)
            {
                boheamoth.GetComponent<AI>().chase = true;
            }
            else
            {
                boheamoth.GetComponent<AI>().chase = false;
            }
        }
    }
}
