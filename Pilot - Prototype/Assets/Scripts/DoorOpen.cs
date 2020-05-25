using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerStay(Collider other)
    {
        if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.RightControl))
        {
            animator.SetTrigger("Open");
        }
    }
}
