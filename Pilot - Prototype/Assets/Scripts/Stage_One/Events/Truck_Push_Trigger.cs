using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck_Push_Trigger : MonoBehaviour
{

    public Animator truck;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.LeftControl))
        {
            //truck.SetTrigger("Pushed");
            gameObject.SetActive(false);
        }
    }
}
