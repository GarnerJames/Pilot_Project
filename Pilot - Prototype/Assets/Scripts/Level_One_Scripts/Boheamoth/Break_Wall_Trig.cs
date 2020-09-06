using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break_Wall_Trig : MonoBehaviour
{

    public GameObject breakableWall;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boheamoth")
        {
            breakableWall.SetActive(false);
        }
    }
}
