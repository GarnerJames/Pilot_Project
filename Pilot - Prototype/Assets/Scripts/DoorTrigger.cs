using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject door;

    void OnTriggerEnter(Collider other)
    {
        door.transform.position += new Vector3(0, 5, 0);
    }
}
