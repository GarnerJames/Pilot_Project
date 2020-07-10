using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoorSwitch : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.LeftControl))
        {
            DoorUnlock.unlocked = true;
        }
    }
}
