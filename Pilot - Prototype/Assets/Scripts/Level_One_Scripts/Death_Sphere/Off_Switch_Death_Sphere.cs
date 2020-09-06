using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Off_Switch_Death_Sphere : MonoBehaviour
{
    public GameObject rayCube;
    public GameObject deathSphere;
    public GameObject followTrig;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetButtonDown("Fire3"))
            {
                rayCube.SetActive(false);
                followTrig.SetActive(false);
                //Play Sound
                deathSphere.GetComponent<Follow>().following = false;
                rayCube.GetComponent<Raycast_Cube>().follow = false;
            }
        }
    }
}
