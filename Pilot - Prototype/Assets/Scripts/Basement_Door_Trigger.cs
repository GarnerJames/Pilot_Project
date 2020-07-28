using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basement_Door_Trigger : MonoBehaviour
{
    public Animator right;
    public Animator left;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.LeftControl))
        {
            right.SetTrigger("Open");
            left.SetTrigger("Open");
        }
    }
}
