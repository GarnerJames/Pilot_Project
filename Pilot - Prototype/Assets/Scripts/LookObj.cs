using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookObj : MonoBehaviour
{

    public Vector3 position;

    public GameObject lookObj;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            lookObj.transform.position = position;
        }
    }
}
