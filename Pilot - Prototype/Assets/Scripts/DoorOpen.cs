using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public Animator animator;

    public GameObject ragdollStand;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    void OnTriggerStay(Collider other)
    {
        if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.LeftControl))
        {
            ragdollStand.SetActive(false);

            animator.SetTrigger("Open");
        }
    }
}
