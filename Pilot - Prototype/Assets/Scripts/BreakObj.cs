using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakObj : MonoBehaviour
{
    //public GameObject brokenVersion;

    public void TakeDamage()
    {
        Break();
    }

    void Break()
    {
        //Instantiate(brokenVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
