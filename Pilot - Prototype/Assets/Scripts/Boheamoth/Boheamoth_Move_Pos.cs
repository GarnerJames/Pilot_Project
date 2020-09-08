using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boheamoth_Move_Pos : MonoBehaviour
{
    public GameObject boheamoth;
    public Vector3 newPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            boheamoth.transform.position = newPos;
        }
    }
}
