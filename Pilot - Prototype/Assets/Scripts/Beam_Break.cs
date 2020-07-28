using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam_Break : MonoBehaviour
{

    public GameObject beam;
    //public GameObject brokenBeam;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Instantiate(brokenBeam, beam.transform.position, beam.transform.rotation);
            Destroy(beam);
        }
    }
}
