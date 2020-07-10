using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUnlock : MonoBehaviour
{

    public static bool unlocked;

    public GameObject doorLight;

    public Material unlockedCol;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        unlocked = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (unlocked)
        {
            doorLight.GetComponent<MeshRenderer>().material = unlockedCol;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && unlocked)
        {
            animator.SetTrigger("Open");
        }
    }
}
