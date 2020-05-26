using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTrigger : MonoBehaviour
{
    public GameObject car;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            car.SetActive(true);
        }
    }
}
