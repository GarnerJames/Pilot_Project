using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pull_Vent : MonoBehaviour
{
    public Animator ventAni;
    public GameObject vent;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetButtonDown("Fire3"))
        {
            ventAni.SetTrigger("Open");
            vent.layer = LayerMask.NameToLayer("NoCol");
        }
    }
}
