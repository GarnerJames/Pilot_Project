using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Trig : MonoBehaviour
{
    public GameObject deathSphere;
    public GameObject raycastCube;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            deathSphere.GetComponent<Follow>().following = true;
            raycastCube.GetComponent<Raycast_Cube>().follow = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            deathSphere.GetComponent<Follow>().following = false;
            raycastCube.GetComponent<Raycast_Cube>().follow = false;
        }
    }
}
