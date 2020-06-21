using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Celing : MonoBehaviour
{
    public GameObject destroyedVersion;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
